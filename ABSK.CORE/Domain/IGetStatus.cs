namespace ABSK.CORE.Domain
{
  public interface IGetStatus<out T>
  {
    T GetStatus();
  }
}