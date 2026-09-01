using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Dtos.User
{
  public class GetCurrentUserDto
  {
    public string Id { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
  }
}
