namespace ABSK.CORE.Domain
{
  public class LastFrame : FrameBase, ILastFrame
  {
    private int? _ballThree;

    public LastFrame(int number)
      : base(number)
    {
    }

    public bool CanRollBonusBall
    {
      get { return IsStrike || IsSpare; }
    }

    public void SetBallThree(int ballThree)
    {
      _ballThree = ballThree;
    }

    protected override bool IsNew
    {
      get { return BallOne == null && BallTwo == null && _ballThree == null; }
    }

    protected override bool IsInProgress
    {
      get { return _ballThree == null && (BallTwo == null || IsStrike || IsSpare); }
    }

    protected override bool IsOver
    {
      get { return _ballThree != null || !IsStrike || !IsSpare; }
    }
  }
}