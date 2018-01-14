using Assets.Scripts.ViewModels.Properties;
using UnityEngine;

namespace Assets.Scripts.Views.Bindings
{
  public class ActivityExternalBinding : ActivityBaseBinding
  {
    public GameObject Target;

    protected override GameObject ActivityTarget { get { return Target; } }
  }
}
