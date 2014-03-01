namespace ABSK.CORE.Domain
{
  public interface ILastFrame : IFrame
  {
    bool CanRollBonusBall { get; }
  }
}