namespace ABSK.CORE.Domain
{
  public interface IFrame
  {
    int Number { get; }
    bool IsStrike { get; }
    bool IsSpare { get; }
    void SetBallOne(int ballOne);
    void SetBallTwo(int ballTwo);
  }
}