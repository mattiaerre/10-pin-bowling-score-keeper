using ABSK.CORE.Domain;
using NUnit.Framework;

namespace ABSK.CORE.TEST.Domain
{
  [TestFixture]
  public class Frame_Test : TestBase
  {
    private const int FrameNumber = 4;
    private IFrame _frame;

    [SetUp]
    public void Given_A_Frame()
    {
      _frame = new Frame(FrameNumber, NumberOfPins);
    }

    [Test]
    public void It_Should_Have_A_Number()
    {
      Assert.AreEqual(FrameNumber, _frame.Number);
    }

    [Test]
    public void It_Should_Be_Able_To_Tell_If_It_Is_A_Strike()
    {
      _frame.SetBallOne(NumberOfPins);

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
    public void At_The_Very_Beginning_It_Should_Be_New()
    {
      Assert.AreEqual(FrameStatus.New, _frame.GetStatus());
    }

    [Test]
    public void After_A_Strike_It_Should_Be_Over()
    {
      _frame.SetBallOne(NumberOfPins);
      Assert.AreEqual(FrameStatus.Over, _frame.GetStatus());
    }

    [Test]
    public void After_A_Spare_It_Should_Be_Over()
    {
      _frame.SetBallOne(5);
      _frame.SetBallTwo(5);
      Assert.AreEqual(FrameStatus.Over, _frame.GetStatus());
    }

    [Test]
    public void After_Two_Balls_It_Should_Be_Over()
    {
      _frame.SetBallOne(4);
      _frame.SetBallTwo(4);
      Assert.AreEqual(FrameStatus.Over, _frame.GetStatus());
    }

    [Test]
    public void After_One_Ball_It_Should_Be_In_Progress()
    {
      _frame.SetBallOne(4);
      Assert.AreEqual(FrameStatus.InProgress, _frame.GetStatus());
    }
  }
}
