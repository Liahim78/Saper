using Assets.Scripts.ViewModels;
using UnityEngine;

namespace Assets.Scripts.Views
{
  public class Form<T> : MonoBehaviour, IView where T : IViewModel, new()
  {
    private IViewModel viewModel;
    public IViewModel ViewModel
    {
      get
      {
        if (viewModel == null)
          viewModel = new T();
        return viewModel;
      }
    }
  }
}
