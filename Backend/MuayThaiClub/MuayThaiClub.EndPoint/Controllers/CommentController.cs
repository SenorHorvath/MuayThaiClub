using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Logic;
using MuayThaiClub.Logic.Helpers.Interfaces;
using MuayThaiClub.Model.Dtos.Comment;
using MuayThaiClub.Model.Dtos.Post;
using MuayThaiClub.Model.Objects;

namespace MuayThaiClub.EndPoint.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CommentController : ControllerBase
  {
    private ICommentLogic logic;
    private UserManager<AppUser> userManager;
    private RoleManager<IdentityRole> rolemanager;
    public CommentController(ICommentLogic logic,
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
    public async Task<IActionResult> Create(CommentCreateUpdateDto comment, string PostID)
    {
      var user = await userManager.GetUserAsync(User);
      comment.PostID = PostID;
      var CreatedComment = await logic.CreateAsync(comment, user!.Id);
      return Ok(CreatedComment);
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
