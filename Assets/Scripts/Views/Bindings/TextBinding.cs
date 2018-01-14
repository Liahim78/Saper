using Assets.Scripts.ViewModels.Properties;
using System;
using UnityEngine.UI;

namespace Assets.Scripts.Views.Bindings
{
  public class TextBinding : BaseBinding
  {
    public string Path;

    public Text Text;

    private IProperty _property;

    private Func<string> _getter;

    private bool isChange = false;

    protected override void Unbind()
    {
      _getter = null;
      Unsubscribe(ref _property);
    }

    protected override void Bind()
    {
      _property = FindProperty(Path);
      if (_property == null) return;
      _getter = () => { return (_property as Property<string>).Value; };
      _property.OnChange += OnChange;
    }

    private void Update()
    {
      if (isChange)
      {
        Text.text = _getter();
        isChange = false;
      }
    }

    protected override void OnChange()
    {
      isChange = true;
      base.OnChange();
    }
  }
}
