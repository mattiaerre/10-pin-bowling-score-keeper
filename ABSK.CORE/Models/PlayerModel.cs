using ABSK.CORE.Domain;
using System.Collections.Generic;

namespace ABSK.CORE.Models
{
  public class PlayerModel
  {
    public string Name { get; set; }
    public IEnumerable<IFrame> Frames { get; set; }
    public ILastFrame LastFrame { get; set; }
  }
}
