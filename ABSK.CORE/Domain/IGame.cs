using ABSK.CORE.Models;
using System.Collections.Generic;

namespace ABSK.CORE.Domain
{
  public interface IGame : IGetStatus<GameStatus>
  {
    void AddPlayer(string name);
    IEnumerable<PlayerModel> Players { get; }
    IEnumerable<int> Frames { get; }
  }
}