using Microsoft.AspNetCore.Mvc;
using MuayThaiClub.Logic;
using MuayThaiClub.Logic.Helpers.Exceptions;
using MuayThaiClub.Model.Dtos.UserDto;

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
      await logic.Register(user);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserLoginDto user)
    {
      var result = await logic.Login(user);
      return Ok(result);
    }
  }
}
