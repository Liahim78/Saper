using Assets.Scripts.ViewModels;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts.Views.Components
{
  public class OnButtonClick: MonoBehaviour
  {
    public string Path;

    public void Event()
    {
      var current = transform;
      var view = current.GetComponent<IView>();
      while (view == null && current.parent != null)
      {
        current = current.parent;
        view = current.GetComponent<IView>();
      }
      MethodInfo mi = view.ViewModel.GetType().GetMethod(Path);
      mi.Invoke(view.ViewModel, new object[0]);
    }
  }
}
