using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.EndPoint.Helpers.Classes;
using MuayThaiClub.Logic;
using MuayThaiClub.Logic.Helpers.Exceptions;
using MuayThaiClub.Model.Dtos.User;
using MuayThaiClub.Model.Dtos.UserDto;
using System.Security.Claims;

namespace MuayThaiClub.EndPoint.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UserController : ControllerBase
  {
    UserLogic logic;
    public UserController(UserLogic logic)
    {
      this.logic = logic;
    }

    [HttpPost("Register")]
    public async Task Register(UserRegisterDto user)
    {
      Console.WriteLine(user.DateOfBirth);
      await logic.Register(user);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginDto user)
    {
      var result = await logic.Login(user);
      Response.Cookies.Append("access_token", result.AccessToken, new CookieOptions
      {
        HttpOnly = true,
        Secure = true,
        SameSite = SameSiteMode.None,
        Expires = result.AccessTokenExpiration
      });

      return Ok();
    }
    [HttpPost("ChangeProfilePicture")]
    [Consumes("multipart/form-data")]
    [Authorize]
    public async Task<IActionResult> ChangeProfilePicture([FromForm] FileUploadRequest request)
    {
      var file = request.File;
      if (file == null || file.Length == 0)
        return BadRequest("No file has been selected.");

      using var stream = file.OpenReadStream();

      var dto = new UserFileUploadDto
      {
        Content = stream,
        Extension = Path.GetExtension(file.FileName).ToLowerInvariant(),
        ContentType = file.ContentType
      };

      var UserID = User.FindFirstValue(ClaimTypes.NameIdentifier);
      
      await logic.ChangeProfilePicture(dto, UserID!);
      return Ok();
    }
  }
}
