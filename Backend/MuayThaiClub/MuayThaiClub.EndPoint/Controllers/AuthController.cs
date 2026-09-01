using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.EndPoint.Helpers.Classes;
using MuayThaiClub.Logic;
using MuayThaiClub.Logic.Helpers.Exceptions;
using MuayThaiClub.Logic.Helpers.Interfaces;
using MuayThaiClub.Model.Dtos.User;
using MuayThaiClub.Model.Dtos.UserDto;
using System.Security.Claims;

namespace MuayThaiClub.EndPoint.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AuthController : ControllerBase
  {
    IAuthLogic logic;
    public AuthController(IAuthLogic logic)
    {
      this.logic = logic;
    }

    [HttpPost("Register")]
    public async Task Register(AuthRegisterDto user)
    {
      Console.WriteLine(user.DateOfBirth);
      await logic.Register(user);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(AuthLoginDto user)
    {
      var result = await logic.Login(user);
      Response.Cookies.Append("access_token", result.AccessToken, new CookieOptions
      {
        HttpOnly = true,
        Secure = true,
        SameSite = SameSiteMode.None,
        Expires = result.AccessTokenExpiration
      });

      return Ok(result);
    }
    
    [Authorize]
    [HttpGet("me")]
    public IActionResult GetCurrentUser() 
    {
      return Ok(new GetCurrentUserDto{
        Id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
        UserName = User.Identity?.Name
      });
    }

  }
}
