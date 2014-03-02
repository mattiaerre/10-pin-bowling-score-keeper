namespace ABSK.CORE.Domain
{
  public abstract class FrameBase : IFrame
  {
    private readonly int _numberOfPins;
    protected int? BallOne;
    protected int? BallTwo;

    protected FrameBase(int number, int numberOfPins)
    {
      _numberOfPins = numberOfPins;
      Number = number; // todo: move up
    }

    public int Number { get; private set; }

    public bool IsStrike
    {
      get { return BallOne == _numberOfPins; }
    }

    public bool IsSpare
    {
      get { return !IsStrike && BallOne + BallTwo == _numberOfPins; }
    }

    protected abstract bool IsNew { get; }

    protected abstract bool IsInProgress { get; }

    protected abstract bool IsOver { get; }

    public void SetBallOne(int ballOne)
    {
      // todo: add exception handling
      BallOne = ballOne;
    }

    public void SetBallTwo(int ballTwo)
    {
      // todo: add exception handling
      BallTwo = ballTwo;
    }

    public FrameStatus GetStatus()
    {
      if (IsNew)
        return FrameStatus.New;
      if (IsInProgress)
        return FrameStatus.InProgress;
      if (IsOver)
        return FrameStatus.Over;
      return FrameStatus.Unknown;
    }
  }
}
