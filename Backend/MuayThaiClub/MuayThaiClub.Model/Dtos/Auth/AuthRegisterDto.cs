using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Dtos.UserDto
{
  public class AuthRegisterDto
  {
    [MaxLength(255)]
    public required string EmailAddress { get; set; } = "";

    [MaxLength(255)]
    public required string UserName { get; set; } = "";

    [MaxLength(255)]
    public required string Password { get; set; } = "";

    public required DateTime DateOfBirth { get; set; } = new DateTime();
  }
}
