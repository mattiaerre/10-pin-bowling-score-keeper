using ABSK.CORE.Domain;
using NUnit.Framework;

namespace ABSK.CORE.TEST.Domain
{
  [TestFixture]
  public class LastFrame_Test
  {
    private const int FrameNumber = 10;
    private ILastFrame _frame;

    [SetUp]
    public void Given_A_Frame()
    {
      _frame = new LastFrame(FrameNumber);
    }

    [Test]
    public void It_Should_Be_Able_To_Tell_If_It_Is_A_Strike()
    {
      _frame.SetBallOne(10);

      Assert.IsTrue(_frame.IsStrike);
    }

    [Test]
    public void It_Should_Be_Able_To_Tell_If_It_Is_A_Spare()
    {
      _frame.SetBallOne(6);
      _frame.SetBallTwo(4);

      Assert.IsTrue(_frame.IsSpare);
    }

    [Test]
    public void It_Should_Give_You_A_Bonus_Ball_If_It_Is_A_Strike()
    {
      _frame.SetBallOne(10);
      _frame.SetBallTwo(4);

      Assert.IsTrue(_frame.CanRollBonusBall);
    }
    [Test]
    public void It_Should_Give_You_A_Bonus_Ball_If_It_Is_A_Spare()
    {
      _frame.SetBallOne(7);
      _frame.SetBallTwo(3);

      Assert.IsTrue(_frame.CanRollBonusBall);
    }
  }
}