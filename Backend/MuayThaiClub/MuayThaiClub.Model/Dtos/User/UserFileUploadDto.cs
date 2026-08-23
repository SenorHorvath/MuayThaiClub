using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Dtos.User
{
  public class UserFileUploadDto
  {
    public Stream Content { get; set; } = new MemoryStream();
    public string Extension { get; set; } = "";
    public string ContentType { get; set; } = "";

  }
}
