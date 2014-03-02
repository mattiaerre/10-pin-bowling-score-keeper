using ABSK.CORE.Models;
using ABSK.CORE.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ABSK.CORE.Domain
{
  public class Game : IGame
  {
    private readonly IPlayerRepository _repository;
    private readonly int _numberOfFrames;

    public Game(IPlayerRepository repository, int numberOfFrames)
    {
      _repository = repository;
      _numberOfFrames = numberOfFrames;
    }

    public GameStatus GetStatus()
    {
      var players = _repository.GetAll();
      foreach (var player in players)
      {
        var frames = player.Frames.Union(new[] { player.LastFrame });
        if (frames.Any(e => e.GetStatus() == FrameStatus.New || e.GetStatus() == FrameStatus.InProgress))
          return GameStatus.InProgress; // info: if there is at least one frame in progress
      }
      return GameStatus.Over;
    }

    public void AddPlayer(string name)
    {
      _repository.Add(name);
    }

    public IEnumerable<PlayerModel> Players
    {
      get { return _repository.GetAll(); }
    }

    public IEnumerable<int> Frames {
      get {
        return MakeFramesStructure();
      }
    }

    private IEnumerable<int> MakeFramesStructure()
    {
      var list = new List<int>();
      for (var i = 1; i <= _numberOfFrames; i++)
      {
        list.Add(i);
      }
      return list;
    }
  }
}