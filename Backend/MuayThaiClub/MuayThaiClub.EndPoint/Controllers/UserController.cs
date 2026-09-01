using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuayThaiClub.EndPoint.Helpers.Classes;
using MuayThaiClub.Logic;
using MuayThaiClub.Logic.Helpers.Interfaces;
using MuayThaiClub.Model.Dtos.User;
using System.Security.Claims;

namespace MuayThaiClub.EndPoint.Controllers
{
  [ApiController]
  [Route("[Controller]")]
  public class UserController : ControllerBase
  {
    IUserLogic logic;

    public UserController(IUserLogic logic)
    {
      this.logic = logic;
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
