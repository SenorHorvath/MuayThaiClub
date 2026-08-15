using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Logic.Helpers.Exceptions;
using MuayThaiClub.Model.Dtos.UserDto;
using MuayThaiClub.Model.Objects.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MuayThaiClub.Logic
{
  public class UserLogic
  {
    private UserManager<AppUser> userManager;
    private RoleManager<IdentityRole> roleManager;
    private readonly IConfiguration configuration;

    public UserLogic(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager,
      IConfiguration configuration)
    {
      this.userManager = userManager;
      this.roleManager = roleManager;
      this.configuration = configuration;
    }

    public async Task<UserLoginResultDto> Login(UserLoginDto UserLogin)
    {

      var user = await userManager.FindByEmailAsync(UserLogin.EmailAddress);

      if (user != null)
      {
        var result = await userManager.CheckPasswordAsync(user, UserLogin.Password);
        if (result)
        {

          var claim = new List<Claim>()
          {
           new Claim(ClaimTypes.Name, user.UserName!),
           new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
          };

          foreach (var role in await userManager.GetRolesAsync(user))
          {
            claim.Add(new Claim(ClaimTypes.Role, role));
          }

          int accessTokenExpiryInMinutes = 24 * 60;
          var accessToken = GenerateAccessToken(claim, accessTokenExpiryInMinutes);
          int refreshTokenExpiryInMinutes = 24 * 60 * 7;
          var refreshToken = await GenerateRefreshToken(user);

          return new UserLoginResultDto()
          {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
            AccessTokenExpiration = DateTime.Now.AddMinutes(accessTokenExpiryInMinutes),
            RefreshToken = refreshToken,
            RefreshTokenExpiration = DateTime.Now.AddMinutes(refreshTokenExpiryInMinutes)
          };

        }
        else
        {
          throw new LoginException("The email address or password is not correct.");
        }
      }
      else
      {
        throw new LoginException("The email address or password is not correct.");
      }

    }

    public async Task Register(UserRegisterDto user)
    {
      var NewUser = new AppUser()
      {
        UserName = user.UserName,
        Email = user.EmailAddress,
        RefreshToken = ""
      };

      await userManager.CreateAsync(NewUser, user.Password);

      if (userManager.Users.Count() == 1)
      {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await userManager.AddToRoleAsync(NewUser, "Admin");
      }
    }

    private JwtSecurityToken GenerateAccessToken(IEnumerable<Claim>? claims, int expiryInMinutes)
    {
      var signinKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["jwt:key"] ?? throw new Exception("jwt:key not found in appsettings.json")));

      return new JwtSecurityToken(
            issuer: "muaythaiclub.com",
            audience: "muaythaiclub.com",
            claims: claims?.ToArray(),
            expires: DateTime.Now.AddMinutes(expiryInMinutes),
            signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
          );
    }

    private async Task<string> GenerateRefreshToken(AppUser user)
    {
      var randomNumber = new byte[32];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(randomNumber);
        string result = Convert.ToBase64String(randomNumber);
        user.RefreshToken = result;
        await userManager.UpdateAsync(user);
        return result;
      }
    }
  }
}
