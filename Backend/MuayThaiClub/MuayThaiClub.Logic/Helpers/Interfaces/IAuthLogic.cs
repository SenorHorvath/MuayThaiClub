using Microsoft.AspNetCore.Identity;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Logic.Helpers.Exceptions;
using MuayThaiClub.Model.Dtos.User;
using MuayThaiClub.Model.Dtos.UserDto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic.Helpers.Interfaces
{
  public interface IAuthLogic
  {
    public Task<AuthLoginResultDto> Login(AuthLoginDto UserLogin);
    public Task Register(AuthRegisterDto user);
  }
}
