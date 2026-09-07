using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using MuayThaiClub.Database.Helpers;
using MuayThaiClub.Database.Helpers.Interfaces;
using MuayThaiClub.Logic;
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
  public class AuthLogicTests
  {
    private Mock<UserManager<AppUser>> userManager;
    private Mock<RoleManager<IdentityRole>> roleManager;
    private readonly Mock<IConfiguration> configuration;
    private Mock<IRepository<User>> repo;
    private IAuthLogic logic;

    [SetUp]
    public void SetUp()
    {
      logic = new AuthLogic(userManager.Object, roleManager.Object, 
        configuration.Object, repo.Object);
    }
  }
}
