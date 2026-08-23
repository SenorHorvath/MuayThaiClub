using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Logic;
using MuayThaiClub.Model.Dtos.Comment;
using MuayThaiClub.Model.Dtos.Post;
using MuayThaiClub.Model.Objects;

namespace MuayThaiClub.EndPoint.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CommentController : ControllerBase
  {
    private CommentLogic logic;
    private UserManager<AppUser> userManager;
    private RoleManager<IdentityRole> rolemanager;
    public CommentController(CommentLogic logic,
      UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager)
    {
      this.logic = logic;
      this.userManager = userManager;
      this.rolemanager = rolemanager;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get(string id)
    {
      return Ok(logic.Get(id));
    }
    [HttpGet("GetAll")]

    public async Task<IActionResult> GetAll()
    {
      return Ok(logic.GetAll());
    }
    [HttpPost("{PostID}")]
    [Authorize]
    public async Task Create(CommentCreateUpdateDto comment, string PostID)
    {
      var user = await userManager.GetUserAsync(User);
      await logic.CreateAsync(comment, PostID, user!.Id);
    }
    [HttpPut]
    [Authorize]
    public async Task Update(string id, CommentCreateUpdateDto comment)
    {
      var user = await userManager.GetUserAsync(User);
      await logic.UpdateAsync(id, comment, user!.Id);

    }

    [HttpDelete]
    [Authorize("Admin")]
    public async Task Delete(string id)
    {
      await logic.DeleteAsync(id);
    }
  }
}
