using MuayThaiClub.Model.Objects;
using MuayThaiClub.Model.Objects.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MuayThaiClub.Model.Objects.Post
{
  public class Post : IIDentity
  {
    public int ID { get; set; }
    [MaxLength(255)]
    public required string Title { get; set; } = "";
    [MaxLength(255)]
    public required string Description { get; set; } = "";
    public DateTime PostDate { get; set; } = new DateTime();
    public virtual User.User CreatorID { get; set; } = new User.User();
  }
}
