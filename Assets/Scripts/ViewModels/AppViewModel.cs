
using Assets.Scripts.Views;
using System.Collections.Generic;

namespace Assets.Scripts.ViewModels
{
  public static class AppViewModel
  {
    public static AppView AppView;

    public static List<RefreshableViewModel> RefreshableViewModels = new List<RefreshableViewModel>();
  }
}
