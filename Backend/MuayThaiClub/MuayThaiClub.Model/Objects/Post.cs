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
  public class Post : IIDentity, ICreatorID
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string ID { get; set; } = Guid.NewGuid().ToString();
    [MaxLength(255)]
    public required string Title { get; set; } = "";
    [MaxLength(255)]
    public required string Description { get; set; } = "";
    public DateTime PostDate { get; set; } = new DateTime();
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    public string CreatorID { get; set; } = "";
  }
}
