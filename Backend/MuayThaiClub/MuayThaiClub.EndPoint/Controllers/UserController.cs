using Microsoft.AspNetCore.Mvc;
using MuayThaiClub.Logic;
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
    public ActionResult<UserRegisterResultDto> Register(UserRegisterDto user)
    {
      return logic.Register(user);
    }

    [HttpPost("Login")]
    public ActionResult<UserLoginResultDto> Login(UserLoginDto user)
    {
      return logic.Login(user);
    }
  }
}
