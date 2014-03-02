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

    public IEnumerable<int> Frames
    {
      get
      {
        return MakeFramesStructure();
      }
    }

    public void SetScore(int?[] score, PlayerModel player, int frameNumber)
    {
      if (frameNumber == player.LastFrame.Number)
      {
        SetScoreLastFrame(score, player.LastFrame);
      }
      else
      {
        var frame = player.Frames.First(e => e.Number == frameNumber);
        SetScoreFrame(score, frame);
      }
    }

    private static void SetScoreFrame(IList<int?> score, IFrame frame)
    {
      if (score[0] != null)
        frame.SetBallOne((int)score[0]);
      if (score.Count() == 2 && score[1] != null)
        frame.SetBallTwo((int)score[1]);
    }

    private static void SetScoreLastFrame(IList<int?> score, ILastFrame lastFrame)
    {
      lastFrame.SetBallOne(score[0] == null ? 0 : (int)score[0]);
      lastFrame.SetBallTwo(score[1] == null ? 0 : (int)score[1]);
      lastFrame.SetBallThree(score[2] == null ? 0 : (int)score[2]);
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