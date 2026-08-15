using MuayThaiClub.Model.Dtos.UserDto;
using MuayThaiClub.Model.Objects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Database.Repositories
{
  public class UserRepository : Repository<User>
  {
    public UserRepository(MuayThaiContext ctx) : base(ctx)
    {
    }

    public UserLoginResultDto Login(UserLoginDto UserLogin) 
    {
      //var user = GetAll().FirstOrDefault(x => (x.EmailAddress == UserLogin.EmailAddress && x.Password == UserLogin.Password));
      IEnumerable<User> user = null;
      
      if (user is not null) 
      {
        return new UserLoginResultDto
        {
          IsSuccessful = true
        };
      }

      return new UserLoginResultDto
      {
        IsSuccessful = false
      };
    }

    public void Register() { }

    public async void LoginAsync()
    { 
    }

    public async void RegisterAsync() 
    { 
    }
  }
}
