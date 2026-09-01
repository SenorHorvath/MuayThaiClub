using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Model.Dtos.UserDto
{
  public class AuthLoginResultDto
  {
    public string AccessToken { get; set; } = "";

    public DateTime AccessTokenExpiration { get; set; }

    public string RefreshToken { get; set; } = "";

    public DateTime RefreshTokenExpiration { get; set; }
  }
}
