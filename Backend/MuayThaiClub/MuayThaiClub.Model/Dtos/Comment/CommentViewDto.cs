using MuayThaiClub.Model.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MuayThaiClub.Model.Dtos.Comment
{
  public class CommentViewDto
  {
    public string ID { get; set; } = "";
    public string Message { get; set; } = "";
    public string ParentCommentID { get; set; } = "";
    public string CreatorID { get; set; } = "";
    public DateTime CreatedAt { get; set; } = new DateTime();
    public ICollection<CommentViewDto> Replies { get; set; } = new List<CommentViewDto>();

  }
}
