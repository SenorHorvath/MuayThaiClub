using AutoMapper;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Logic.Helpers;
using MuayThaiClub.Logic.Helpers.BaseClasses;
using MuayThaiClub.Model.Dtos.Comment;
using MuayThaiClub.Model.Dtos.Post;
using MuayThaiClub.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic
{
  public class CommentLogic : CrudBase<Comment, CommentCreateUpdateDto, CommentViewDto>
  {
    public CommentLogic(Repository<Comment> repo, DtoProvider provider) : base(repo, provider)
    {
    }

    public async Task CreateAsync(CommentCreateUpdateDto e, string PostID, string UserID)
    {
      var comment = mapper.Map<Comment>(e);
      comment.PostID = PostID;
      comment.ParentCommentID = e.ParentCommentID == "" ? null : e.ParentCommentID;
      comment.CreatorID = UserID;
      await repo.CreateAsync(comment);
    }

    public override IEnumerable<CommentViewDto> GetAll()
    {
      return repo.GetAll().ToList().Select(x => mapper.Map<CommentViewDto>(x))
        .Where(c => c.ParentCommentID == null);
    }
    //private Repository<Comment> repo;
    //private Mapper mapper;

    //public CommentLogic(Repository<Comment> repo, DtoProvider provider)
    //{
    //  this.repo = repo;
    //  this.mapper = provider.mapper;
    //}

    //public Task CreateAsync(CommentCreateUpdateDto p, string UserID)
    //{
    //  throw new NotImplementedException();
    //}

    //public Task DeleteAsync(string id)
    //{
    //  throw new NotImplementedException();
    //}

    //public CommentViewDto Get(string id)
    //{
    //  throw new NotImplementedException();
    //}

    //public IEnumerable<CommentViewDto> GetAll()
    //{
    //  throw new NotImplementedException();
    //}

    //public Task UpdateAsync(string id, CommentCreateUpdateDto p, string UserID)
    //{
    //  throw new NotImplementedException();
    //}
  }
}
