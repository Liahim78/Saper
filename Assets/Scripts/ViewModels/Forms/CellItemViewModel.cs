
namespace Assets.Scripts.ViewModels.Forms
{
  public class CellItemViewModel : SimpleViewModel, ISettable<CellItemViewModel.Parametrs>
  {
    public class Parametrs
    {
      public int X;
      public int Y;
    }

    private int x;
    private int y;

    public void Set(Parametrs parametrs)
    {
      x = parametrs.X;
      y = parametrs.Y;
    }
  }
}
