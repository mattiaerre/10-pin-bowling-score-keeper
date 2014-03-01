using ABSK.CORE.Domain;
using ABSK.CORE.Models;
using System.Collections.Generic;

namespace ABSK.CORE.Factories
{
  public class PlayerModelFactory : IPlayerModelFactory
  {
    private readonly int _numberOfFrames;
    private readonly int _numberOfPins;

    public PlayerModelFactory(int numberOfFrames, int numberOfPins)
    {
      _numberOfFrames = numberOfFrames;
      _numberOfPins = numberOfPins;
    }

    public PlayerModel Make(string name)
    {
      return new PlayerModel
      {
        Name = name,
        Frames = MakeFrames(_numberOfFrames, _numberOfPins),
        LastFrame = new LastFrame(_numberOfFrames, _numberOfPins),
      };
    }

    private static IEnumerable<Frame> MakeFrames(int numberOfFrames, int numberOfPins)
    {
      var list = new List<Frame>();
      for (var i = 1; i < numberOfFrames; i++)
        list.Add(new Frame(i, numberOfPins));
      return list;
    }
  }
}
