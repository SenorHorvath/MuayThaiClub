using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuayThaiClub.Model.Dtos.Comment;
using MuayThaiClub.Model.Objects;

namespace MuayThaiClub.Model.Dtos.Post
{
  public class PostViewDto
  {
    public string ID { get; set; }
    [MaxLength(255)]
    public required string Title { get; set; } = "";
    [MaxLength(255)]
    public required string Description { get; set; } = "";

    public string CreatorID { get; set; } = "";
    //public ICollection<CommentViewDto> Comments { get; set; } = new List<CommentViewDto>();

  }
}
