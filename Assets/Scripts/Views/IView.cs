using Assets.Scripts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Views
{
  public interface IView
  {
    IViewModel ViewModel { get; }
  }
}
