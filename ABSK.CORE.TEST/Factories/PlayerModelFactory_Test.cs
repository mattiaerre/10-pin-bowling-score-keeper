using ABSK.CORE.Domain;
using ABSK.CORE.Factories;
using ABSK.CORE.Models;
using NUnit.Framework;
using System.Linq;

namespace ABSK.CORE.TEST.Factories
{
  [TestFixture]
  public class PlayerModelFactory_Test
  {
    private const string Name = "The Dude";
    private IPlayerModelFactory _factory;

    [SetUp]
    public void Given_A_PlayerModelFactory()
    {
      _factory = new PlayerModelFactory();
    }

    [Test]
    public void It_Should_Be_Able_To_Return_A_PlayerModel()
    {
      var model = _factory.Make(Name);

      Assert.IsTrue(model.GetType() == typeof(PlayerModel));
    }

    [Test]
    public void It_Should_Be_Able_To_Return_A_PlayerModel_With_9_Frames()
    {
      var model = _factory.Make(Name);

      Assert.AreEqual(Constants.NumberOfFrames - 1, model.Frames.Count());
    }

    [Test]
    public void It_Should_Be_Able_To_Return_A_PlayerModel_With_1_LastFrame()
    {
      var model = _factory.Make(Name);

      Assert.AreEqual(10, model.LastFrame.Number);
    }
  }
}