using System;
using ABSK.CORE.Models;

namespace ABSK.CORE.Repositories
{
  public interface IPlayerRepository
  {
    Guid Add(string name);
    PlayerModel Get(Guid playerId);
  }
}