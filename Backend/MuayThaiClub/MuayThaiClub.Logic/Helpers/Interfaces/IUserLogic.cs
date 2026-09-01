using MuayThaiClub.Model.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Logic.Helpers.Interfaces
{
  public interface IUserLogic
  {
    public Task ChangeProfilePicture(UserFileUploadDto file, string UserID);
  }
}
