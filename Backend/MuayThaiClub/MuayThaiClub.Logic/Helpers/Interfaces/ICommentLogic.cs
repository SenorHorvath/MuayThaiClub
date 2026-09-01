using AutoMapper;
using MuayThaiClub.Model.Dtos.Comment;
using MuayThaiClub.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic.Helpers.Interfaces
{
  public interface ICommentLogic
  {

    public CommentViewDto Get(string id);
    public IEnumerable<CommentViewDto> GetAll();
    public Task UpdateAsync(string id, CommentCreateUpdateDto e, string UserID);
    public Task DeleteAsync(string id);
    public Task<CommentViewDto> CreateAsync(CommentCreateUpdateDto e, string UserID);
  }
}
