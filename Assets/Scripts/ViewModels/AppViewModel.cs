
using Assets.Scripts.Views;
using System.Collections.Generic;

namespace Assets.Scripts.ViewModels
{
  public static class AppViewModel
  {
    public static AppView AppView;
    private static bool noChanges;
    private static bool NoChanges
    {
      set
      {
        if (value == false)
        {
          RefreshableViewModels.AddRange(tempAdd);
          RefreshableViewModels.RemoveAll(item=>tempRemove.Contains(item));
          tempAdd.Clear();
        }
        noChanges = value;
      }
    }
    private static List<RefreshableViewModel> RefreshableViewModels = new List<RefreshableViewModel>();
    private static List<RefreshableViewModel> tempAdd = new List<RefreshableViewModel>();
    private static List<RefreshableViewModel> tempRemove = new List<RefreshableViewModel>();

    public static void AddRefresh(RefreshableViewModel item)
    {
      if (noChanges)
        tempAdd.Add(item);
      else
        RefreshableViewModels.Add(item);
    }

    public static void RemoveRefresh(RefreshableViewModel item)
    {
      if (noChanges)
        tempRemove.Add(item);
      else
        RefreshableViewModels.Remove(item);
    }

    public static IEnumerable<RefreshableViewModel> GetRefresh()
    {
      NoChanges = true;
      foreach (var item in RefreshableViewModels)
      {
        yield return item;
      }
      NoChanges = false;
      yield break;
    }
  }
}
