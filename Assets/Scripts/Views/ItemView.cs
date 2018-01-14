using System;
using Assets.Scripts.ViewModels;
using UnityEngine;

namespace Assets.Scripts.Views
{
  public class ItemView : MonoBehaviour, IView
  {
    private IViewModel _viewModel;

    public IViewModel ViewModel
    {
      get
      {
        return _viewModel;
      }
    }

    public event Action OnChange;

    public void Set(IViewModel viewModel)
    {
      Debug.Log("Set " + viewModel.ToString());
      _viewModel = viewModel;
      if (OnChange != null)
        OnChange();
    }
  }
}
