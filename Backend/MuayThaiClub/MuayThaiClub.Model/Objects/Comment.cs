using MuayThaiClub.Model.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Objects
{
  public class Comment : IIDentity, ICreatorID
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; } = Guid.NewGuid().ToString();
    [MaxLength(250)]
    public required string Message { get; set; }
    public string? PostID { get; set; } = null;
    public string? ParentCommentID { get; set; } = null;
    public string? CreatorID { get; set; } = null;
    public DateTime CreatedAt { get; set; } = new DateTime();
    public virtual ICollection<Comment> Replies { get; set; } = new List<Comment>();
    public virtual Comment? ParentComment { get; set; } = null;
    public virtual Post Post { get; set; } = null;
  }
}
