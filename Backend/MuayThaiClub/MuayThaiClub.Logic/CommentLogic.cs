using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MuayThaiClub.Database.Helpers.Interfaces;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Logic.Helpers;
using MuayThaiClub.Logic.Helpers.BaseClasses;
using MuayThaiClub.Logic.Helpers.Interfaces;
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
  public class CommentLogic : CrudBase<Comment, CommentCreateUpdateDto, CommentViewDto>, ICommentLogic
  {
    public CommentLogic(IRepository<Comment> repo, DtoProvider provider) : base(repo, provider)
    {
    }

    public async override Task<CommentViewDto> CreateAsync(CommentCreateUpdateDto e, string UserID)
    {
      var comment = mapper.Map<Comment>(e);
      comment.ParentCommentID = e.ParentCommentID == "" ? null : e.ParentCommentID;
      comment.CreatorID = UserID;
      await repo.CreateAsync(comment);
      return mapper.Map<CommentViewDto>(comment);

    }

    public override IEnumerable<CommentViewDto> GetAll()
    {
      return repo.GetAll().ToList().Select(x => mapper.Map<CommentViewDto>(x))
        .Where(c => c.ParentCommentID == null);
    }
    
  }
}
