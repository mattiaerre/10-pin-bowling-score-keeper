namespace ABSK.CORE.Domain
{
  public class LastFrame : Frame, ILastFrame
  {
    public LastFrame(int number)
      : base(number)
    {
    }

    public bool CanRollBonusBall
    {
      get { return IsStrike || IsSpare; }
    }
  }
}