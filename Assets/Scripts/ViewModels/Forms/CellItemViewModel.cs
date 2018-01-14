
using Assets.Scripts.Models;
using Assets.Scripts.Models.Commands;
using Assets.Scripts.ViewModels.Properties;
using Assets.Scripts.Views.Popups;

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
    public Property<bool> Disable = new Property<bool>();
    public Property<bool> Count = new Property<bool>();
    public Property<bool> Flag = new Property<bool>();
    public CellItemViewModel():base(true)
    {

    }

    public void Set(Parametrs parametrs)
    {
      x = parametrs.X;
      y = parametrs.Y;
      OnBegin();
    }

    public override void Subscribe(User user)
    {
      user.GetGameZone(x,y).OnChange += Refresh;
      user.GetOpenedZone(x,y).OnChange += Refresh;
      user.Flags.OnChange += Refresh;
    }

    public override void Refresh(User user)
    {
      IconIndex.Set(user.GetGameZone(x, y).Value);
      Count.Set(user.GetOpenedZone(x, y).Value);
      var point = new Point(y, x);
      Disable.Set(!user.GetOpenedZone(x, y).Value && !user.Flags.Contains(point));
      Flag.Set(!user.GetOpenedZone(x, y).Value && user.Flags.Contains(point));
    }

    public void OnClick()
    {
      new ClickCmd(x, y).Execute();
    }

    public bool Equal(Parametrs parametrs)
    {
      return x == parametrs.X && y == parametrs.Y;
    }
  }
}
