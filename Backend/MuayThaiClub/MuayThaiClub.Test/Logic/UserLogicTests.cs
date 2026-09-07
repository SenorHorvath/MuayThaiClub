using Microsoft.AspNetCore.Identity;
using Moq;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Database.Helpers.Interfaces;
using MuayThaiClub.Database.Repositories;
using MuayThaiClub.Logic;
using MuayThaiClub.Logic.Helpers;
using MuayThaiClub.Logic.Helpers.Interfaces;
using MuayThaiClub.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuayThaiClub.Test.Logic
{
  [TestFixture]
  public class UserLogicTests
  {
    private Mock<IRepository<User>> repo;
    private Mock<UserManager<AppUser>> usermanager; 
    private Mock<IFileService> fileservice; 
    private IUserLogic logic;

    [SetUp]
    public void SetUp() {
      logic = new UserLogic(repo.Object, usermanager.Object,
        fileservice.Object, new DtoProvider());
    }
  }
}
