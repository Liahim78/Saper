using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels.Properties
{
  class BindingArgs<T>:EventArgs
  {
    public T Value { get; set; }

    public BindingArgs(T value)
    {
      Value = value;
    }
  }
}
