using AutoMapper;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Logic.Helpers;
using MuayThaiClub.Logic.Helpers.BaseClasses;
using MuayThaiClub.Logic.Helpers.Interfaces;
using MuayThaiClub.Model.Dtos.Post;
using MuayThaiClub.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic
{
  public class PostLogic : CrudBase<Post, PostCreateUpdateDto, PostViewDto>, IPostLogic
  {
    public PostLogic(Repository<Post> repo, DtoProvider provider) : base(repo, provider)
    {
            
    }
    //private Repository<Post> repo;
    //private Mapper mapper;

    //public PostLogic(Repository<Post> repo, DtoProvider provider)
    //{
    //  this.repo = repo;
    //  this.mapper = provider.mapper;
    //}

    //public PostViewDto Get(string id)
    //{
    //  var r = repo.GetByID(id);
    //  return mapper.Map<PostViewDto>(r);
    //}

    //public IEnumerable<PostViewDto> GetAll()
    //{
    //  return repo.GetAll().Select(x => mapper.Map<PostViewDto>(x));
    //}

    //public async Task CreateAsync(PostCreateUpdateDto p, string UserID)
    //{
    //  var post = mapper.Map<Post>(p);
    //  post.CreatorID = UserID;
    //  await repo.CreateAsync(post);
    //}
    //public async Task UpdateAsync(string id, PostCreateUpdateDto dto, string UserID)
    //{
    //  var PostToUpdate = repo.GetByID(id);
    //  if (PostToUpdate.CreatorID == UserID)
    //  {
    //    if (PostToUpdate != null)
    //    {
    //      mapper.Map(dto, PostToUpdate);
    //      await repo.UpdateAsync(PostToUpdate);
    //    }
    //  }
    //  else
    //    throw new UnauthorizedAccessException("The post cannot be modified " +
    //      "by other than the owner.");
    //}

    //public void Delete(string id)
    //{
    //  repo.DeleteByID(id);
    //}

    //public async Task DeleteAsync(string id)
    //{
    //  await repo.DeleteByIDAsync(id);
    //}

  }
}
