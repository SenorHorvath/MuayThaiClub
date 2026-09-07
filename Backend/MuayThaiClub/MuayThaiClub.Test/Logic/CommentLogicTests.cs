using Moq;
using MuayThaiClub.Database.Helpers.Interfaces;
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
  public class CommentLogicTests
  {
    private Mock<IRepository<Comment>> repo;
    private ICommentLogic logic;

    [SetUp]
    public void SetUp()
    {
      logic = new CommentLogic(repo.Object, new DtoProvider());
    }
  }
}
