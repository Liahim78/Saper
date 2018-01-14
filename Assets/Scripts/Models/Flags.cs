using Assets.Scripts.ViewModels;
using Assets.Scripts.Views.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
  public class Flags : List<Point>
  {
    public event Action<User> OnChange;

    public void Add(Point point)
    {
      base.Add(point);
      if (OnChange != null)
        OnChange(AppModel.GetUser());
      Check();
    }

    public void Remove(Point point)
    {
      base.Remove(point);
      if (OnChange != null)
        OnChange(AppModel.GetUser());
      Check();
    }

    private void Check()
    {
      var user = AppModel.GetUser();
      if (this.All(point => user.GetGameZone(point.J, point.I).Value == -1) && Count == user.AllBombs.Value)
      {
        user.FinishGame();
        AppViewModel.AppView.OpenPopup(PopupType.WinGamePopup);
      }
    }
  }
}
