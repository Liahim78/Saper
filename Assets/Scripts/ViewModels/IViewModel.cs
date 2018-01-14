using Assets.Scripts.ViewModels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels
{
  public interface IViewModel
  {
    IProperty FindProperty(string path);
    Delegate FindMethod(string path);
    void OnDestroy();
  }
}
