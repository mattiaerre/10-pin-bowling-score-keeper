using ABSK.CORE.Models;

namespace ABSK.CORE.Factories
{
  public interface IPlayerModelFactory
  {
    PlayerModel Make(string name);
  }
}