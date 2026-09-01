using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Dtos.User
{
  public class UserViewDto
  {
    public string ID { get; set; } = "";
    public string UserName { get; set; } = "";
    public string EmailAddress { get; set; } = "";
    public string PhotoUrl { get; set; } = "";
    public DateTime DateOfBirth { get; set; } = new DateTime();
  }
}
