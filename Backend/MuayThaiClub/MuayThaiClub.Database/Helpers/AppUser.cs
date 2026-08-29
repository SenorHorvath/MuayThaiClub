using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Database.Helpers
{
  public class AppUser : IdentityUser
  {

    [StringLength(200)]
    public required string RefreshToken { get; set; } = "";
    public string PhotoUrl { get; set; } = "";
    public required DateTime DateOfBirth { get; set; } = new DateTime();
  }
}
