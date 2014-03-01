using ABSK.CORE.Domain;
using NUnit.Framework;

namespace ABSK.CORE.TEST.Domain
{
  [TestFixture]
  public class Frame_Test
  {
    private const int FrameNumber = 4;
    private IFrame _frame;

    [SetUp]
    public void Given_A_Frame()
    {
      _frame = new Frame(FrameNumber);
    }

    [Test]
    public void It_Should_Have_A_Number()
    {
      Assert.AreEqual(FrameNumber, _frame.Number);
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
  }
}
