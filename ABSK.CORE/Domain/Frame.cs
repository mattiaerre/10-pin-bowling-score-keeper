namespace ABSK.CORE.Domain
{
  public class Frame : FrameBase
  {
    public Frame(int number, int numberOfPins)
      : base(number, numberOfPins)
    {
    }

    protected override bool IsNew
    {
      get { return BallOne == null && BallTwo == null; }
    }

    protected override bool IsInProgress
    {
      get
      {
        if (IsStrike)
          return false;
        if (IsSpare)
          return false;
        if (BallOne != null && BallTwo != null)
          return false;
        return true;
      }
    }

    protected override bool IsOver
    {
      get
      {
        if (IsStrike)
          return true;
        if (IsSpare)
          return true;
        if (BallOne != null && BallTwo != null)
          return true;
        return false;
      }
    }
  }
}