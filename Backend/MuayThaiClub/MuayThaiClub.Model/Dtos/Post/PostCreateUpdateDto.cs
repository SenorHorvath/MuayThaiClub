using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Dtos.Post
{
  public class PostCreateUpdateDto
  {
    [MaxLength(255)]
    public required string Title { get; set; } = "";
    [MaxLength(255)]
    public required string Description { get; set; } = "";
  }
}
