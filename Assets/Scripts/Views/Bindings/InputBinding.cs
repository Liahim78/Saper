using Assets.Scripts.ViewModels.Properties;
using System;
using UnityEngine.UI;

namespace Assets.Scripts.Views.Bindings
{
  public class InputBinding : BaseBinding
  {
    public string Path;

    public InputField InputField;

    private IProperty _property;

    protected override void Unbind()
    {
      Unsubscribe(ref _property);
    }

    protected override void Bind()
    {
      _property = FindProperty(Path);
      if (_property == null) return;
    }
    
    protected override void OnChange()
    {
      var stringProperty = _property as Property<string>;
      if (stringProperty == null) return;
      stringProperty.Set(InputField.text);
    }

    public void EndChanging()
    {
      OnChange();
    }
  }
}
