using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Model.Objects.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic
{
  public class PostLogic
  {
    private Repository<Post> repo;

    public PostLogic(Repository<Post> repo)
    {
      this.repo = repo;
    }

    public void Create(Post p) 
    {
      repo.Create(p);
    }

    public async void CreateAsync(Post p)
    {
      repo.CreateAsync(p);
    }

    public void Update(Post p)
    {
      repo.Update(p);
    }
    public async void UpdateAsync(Post p)
    {
      repo.UpdateAsync(p);
    }

    public void Delete(int id)
    {
      repo.DeleteByID(id);
    }

    public void DeleteAsync(int id) 
    {
      repo.DeleteByIDAsync(id);
    }

  }
}
