
using Assets.Scripts.Models;
using Assets.Scripts.ViewModels.Properties;

namespace Assets.Scripts.ViewModels.Forms
{
  public class CellItemViewModel : RefreshableViewModel, ISettable<CellItemViewModel.Parametrs>
  {
    public class Parametrs
    {
      public int X;
      public int Y;

      public override bool Equals(object obj)
      {
        var o = obj as Parametrs;
        if (o == null)
          return false;
        return o.X == X && o.Y == Y;
      }

      public override int GetHashCode()
      {
        return X * Y;
      }
    }

    private int x;
    private int y;

    public Property<int> IconIndex = new Property<int>();
    public Property<int> IsAlreadyOpened = new Property<int>();

    public void Set(Parametrs parametrs)
    {
      x = parametrs.X;
      y = parametrs.Y;
      SetValues();
    }

    public override void Refresh()
    {
      SetValues();
    }

    private void SetValues()
    {
      IconIndex.Set(AppModel.GetGameZone(x, y));
      IsAlreadyOpened.Set(AppModel.GetOpenedZone(x,y)?1:0);
    }

    public void OnClick()
    {
      AppModel.OnClick(x, y);
    }
  }
}
