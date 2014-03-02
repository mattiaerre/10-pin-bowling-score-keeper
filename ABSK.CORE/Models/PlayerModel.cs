using ABSK.CORE.Domain;
using System;
using System.Collections.Generic;

namespace ABSK.CORE.Models
{
  public class PlayerModel
  {
    public string Name { get; set; }
    public IEnumerable<Frame> Frames { get; set; } // todo: use interface
    public LastFrame LastFrame { get; set; } // todo: use interface
  }
}
