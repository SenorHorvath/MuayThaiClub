using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Dtos.Comment
{
  public class CommentCreateUpdateDto
  {
    [MaxLength(250)]
    public required string Message { get; set; }
    public string ParentCommentID { get; set; } = "";
    [JsonIgnore]
    public string PostID { get; set; } = "";
  }
}
