using ABSK.CORE.Domain;
using ABSK.CORE.Factories;
using ABSK.CORE.Repositories;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ABSK.CORE.TEST.Domain
{
  // info: this is more an integration test since I am using PlayerRepository and PlayerModelFactory
  [TestFixture]
  public class Game_Test : TestBase
  {
    private const int OneFrame = 1;
    private IGame _game;

    [SetUp]
    public void Given_A_Game()
    {
      var factory = new PlayerModelFactory(OneFrame, NumberOfPins);
      var repository = new PlayerRepository(factory);
      _game = new Game(repository, OneFrame);
      _game.AddPlayer(TheDude);
    }

    [Test]
    public void At_The_Very_Beginning_The_Status_Is_In_Progress()
    {
      Assert.AreEqual(GameStatus.InProgress, _game.GetStatus());
    }

    [Test]
    public void At_The_End_The_Status_Is_Over()
    {
      var player = _game.Players.First(e => e.Name == TheDude);
      var score = new List<int?> { 10, 10, 10 };
      _game.SetScore(score.ToArray(), player, OneFrame);

      Assert.AreEqual(GameStatus.Over, _game.GetStatus());
    }

    [Test]
    public void It_Should_Expose_A_List_Of_Frames()
    {
      Assert.AreEqual(OneFrame, _game.Frames.Count());
    }
  }
}
