using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Logic;
using MuayThaiClub.Model.Dtos.Post;
using MuayThaiClub.Model.Objects;

namespace MuayThaiClub.EndPoint.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PostController : ControllerBase
  {
    private PostLogic logic;
    UserManager<AppUser> usermanager;
    RoleManager<IdentityRole> rolemanager;
    public PostController(PostLogic logic, UserManager<AppUser> usermanager, RoleManager<IdentityRole> rolemanager)
    {
      this.logic = logic;
      this.usermanager = usermanager;
      this.rolemanager = rolemanager;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get(string id)
    {
      return Ok(logic.Get(id));
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
      return Ok(logic.GetAll());
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create(PostCreateUpdateDto post)
    {
      var user = await usermanager.GetUserAsync(User);
      var CreatedPost = await logic.CreateAsync(post, user!.Id);
      return Ok(CreatedPost);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task Update(string id, PostCreateUpdateDto post)
    {
      var user = await usermanager.GetUserAsync(User);
      await logic.UpdateAsync(id, post, user!.Id);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task Delete(string id)
    {
      await logic.DeleteAsync(id);
    }
  }
}
