using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ViewModels;
using UnityEngine;

namespace Assets.Scripts.Views
{
  public class ItemView : MonoBehaviour, IView
  {
    private IViewModel viewModel;

    public IViewModel ViewModel
    {
      get
      {
        return viewModel;
      }
    }

    public void Set(IViewModel viewModel)
    {
      this.viewModel = viewModel;
    }
  }
}
