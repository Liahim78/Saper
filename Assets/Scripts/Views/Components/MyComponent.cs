using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Views.Components
{
  public class MyComponent : MonoBehaviour
  {
    private bool shouldChange = false;
    
    private void Update()
    {
      if (!shouldChange) return;
      OnChange();
      shouldChange = false;
    }

    public void Change()
    {
      shouldChange = true;
    }

    protected virtual void OnChange()
    {
    }
  }
}
