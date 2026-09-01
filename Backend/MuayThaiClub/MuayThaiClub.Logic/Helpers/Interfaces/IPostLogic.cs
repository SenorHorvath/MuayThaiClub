using MuayThaiClub.Model.Dtos.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic.Helpers.Interfaces
{
  public interface IPostLogic
  {
    public PostViewDto Get(string id);
    public IEnumerable<PostViewDto> GetAll();
    public Task UpdateAsync(string id, PostCreateUpdateDto e, string UserID);
    public Task DeleteAsync(string id);
    public Task<PostViewDto> CreateAsync(PostCreateUpdateDto e, string PostID);
  }
}
