using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Views.Bindings
{
  public abstract class ActivityBaseBinding : BooleanBinding
  {
    protected abstract GameObject ActivityTarget { get; }

    protected override void ApplyNewValue(bool newValue)
    {
      if (ActivityTarget != null)
        ActivityTarget.SetActive(newValue);
      else
        Debug.LogWarning("ActivityTarget not found", gameObject);
    }
  }
}
