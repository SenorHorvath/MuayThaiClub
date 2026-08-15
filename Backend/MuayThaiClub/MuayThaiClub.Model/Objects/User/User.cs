using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Objects.User
{
  public class User : IIDentity
  {
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public string EmailAddress { get; set; } = "";
    public string Password { get; set; } = "";
  }
}
