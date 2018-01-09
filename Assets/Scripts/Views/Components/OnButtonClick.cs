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
      var view = FindObjectOfType<AppView>().GetView(transform);
      MethodInfo mi = view.ViewModel.GetType().GetMethod(Path);
      mi.Invoke(view.ViewModel, new object[0]);
    }
  }
}
