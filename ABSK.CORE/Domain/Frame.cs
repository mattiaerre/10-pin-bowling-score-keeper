namespace ABSK.CORE.Domain
{
  public class Frame : IFrame
  {
    private int _ballOne;
    private int _ballTwo;

    public Frame(int number)
    {
      Number = number;
    }

    public int Number { get; private set; }

    public bool IsStrike
    {
      get { return _ballOne == Constants.NumberOfPins; }
    }

    public bool IsSpare
    {
      get { return _ballOne != Constants.NumberOfPins && _ballOne + _ballTwo == Constants.NumberOfPins; }
    }

    public void SetBallOne(int ballOne)
    {
      // todo: add exception handling
      _ballOne = ballOne;
    }

    public void SetBallTwo(int ballTwo)
    {
      // todo: add exception handling
      _ballTwo = ballTwo;
    }

    public int GetScore()
    {
      return _ballOne + _ballTwo;
    }
  }
}