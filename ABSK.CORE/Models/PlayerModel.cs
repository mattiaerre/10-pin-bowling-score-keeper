using ABSK.CORE.Domain;
using System.Collections.Generic;

namespace ABSK.CORE.Models
{
  public class PlayerModel
  {
    public string Name { get; set; }
    public IEnumerable<Frame> Frames { get; set; }
    public LastFrame LastFrame { get; set; }
  }
}