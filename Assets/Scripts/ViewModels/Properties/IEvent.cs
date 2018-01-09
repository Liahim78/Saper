using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels.Properties
{
  public interface IEvent
  {
    event Action OnChange;
  }
}
