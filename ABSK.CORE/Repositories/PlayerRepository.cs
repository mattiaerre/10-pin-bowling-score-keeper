using System;
using System.Collections.Generic;
using System.Linq;
using ABSK.CORE.Factories;
using ABSK.CORE.Models;

namespace ABSK.CORE.Repositories
{
  public class PlayerRepository : IPlayerRepository
  {
    private readonly IPlayerModelFactory _factory;
    // todo: maybe a "simple" IEnumerable is enough
    private readonly IDictionary<Guid, PlayerModel> _list = new Dictionary<Guid, PlayerModel>();

    public PlayerRepository(IPlayerModelFactory factory)
    {
      _factory = factory;
    }

    public Guid Add(string name)
    {
      var id = Guid.NewGuid();
      var model = _factory.Make(name);
      _list.Add(id, model);
      return id;
    }

    public PlayerModel Get(Guid id)
    {
      // todo: add exception handling
      return _list.First(e => e.Key == id).Value;
    }
  }
}
