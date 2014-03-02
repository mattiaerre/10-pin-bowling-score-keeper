using System.Linq;
using ABSK.CORE.Factories;
using ABSK.CORE.Models;
using ABSK.CORE.Repositories;
using Moq;
using NUnit.Framework;

namespace ABSK.CORE.TEST.Repositories
{
  [TestFixture]
  public class PlayerRepository_Test : TestBase
  {
    private IPlayerRepository _repository;

    [SetUp]
    public void Given_A_PlayerRepository()
    {
      var factory = new Mock<IPlayerModelFactory>();
      factory.Setup(e => e.Make(TheDude)).Returns(new PlayerModel { Name = TheDude });
      _repository = new PlayerRepository(factory.Object);
    }

    [Test]
    public void It_Should_Be_Able_To_Add_A_New_Player()
    {
      var id = _repository.Add(TheDude);

      var player = _repository.Get(id);

      Assert.AreEqual(TheDude, player.Name);
    }

    [Test]
    public void It_Should_Be_Able_To_Return_All_The_Players()
    {
      _repository.Add(TheDude);
      _repository.Add(Walter);
      _repository.Add(Donny);

      Assert.AreEqual(3, _repository.GetAll().Count());
    }
  }
}
