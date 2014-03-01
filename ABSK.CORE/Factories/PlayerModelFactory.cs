using ABSK.CORE.Domain;
using ABSK.CORE.Models;
using System.Collections.Generic;

namespace ABSK.CORE.Factories
{
  public class PlayerModelFactory : IPlayerModelFactory
  {
    public PlayerModel Make(string name)
    {
      return new PlayerModel
      {
        Name = name,
        Frames = MakeFrames(Constants.NumberOfFrames),
        LastFrame = new LastFrame(Constants.NumberOfFrames),
      };
    }

    private static IEnumerable<Frame> MakeFrames(int numberOfFrames)
    {
      var list = new List<Frame>();
      for (var i = 1; i < numberOfFrames; i++)
        list.Add(new Frame(i));
      return list;
    }
  }
}
