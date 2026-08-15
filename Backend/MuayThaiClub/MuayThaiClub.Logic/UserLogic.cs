using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Model.Dtos.UserDto;
using MuayThaiClub.Model.Objects.User;

namespace MuayThaiClub.Logic
{
  public class UserLogic
  {
    private UserRepository repo; 
    public UserLogic(UserRepository repo)
    {
      this.repo = repo;
    }

    public UserLoginResultDto Login(UserLoginDto UserLogin) 
    {
      return repo.Login(UserLogin);
    }

    public UserRegisterResultDto Register(UserRegisterDto user) 
    {
      throw new NotImplementedException();
    }
  }
}
