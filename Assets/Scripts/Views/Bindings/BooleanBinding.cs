using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.ViewModels.Properties;

namespace Assets.Scripts.Views.Bindings
{
  public abstract class BooleanBinding : BaseBinding
  {
    public enum CheckTypes
    {
      Boolean,
      EqualToReference,
      GreaterThanReference,
      LessThanReference,
      Empty
    }

    public string Path;

    public CheckTypes CheckType = CheckTypes.Boolean;

    public double Reference = 0;
    public bool DefaultValue = false;
    public bool Invert = false;

    private bool _ignoreValueChange;

    private IProperty _property;

    private Func<bool> _getter;

    protected override void Unbind()
    {
      _getter = null;
      Unsubscribe(ref _property);
    }

    protected override void Bind()
    {
      _property = FindProperty(Path);
      if (_property == null) return;
      Property.UpdateSubscriber(out _getter, CheckType, _property, Reference, DefaultValue);
      _property.OnChange += OnChange;
    }


    protected override void OnChange()
    {
      if (_ignoreValueChange)
        return;
      
      ApplyValueImpl(_getter == null ? DefaultValue : _getter());
      base.OnChange();
    }

    protected void ApplyValueImpl(bool value)
    {
      ApplyNewValue(Invert ? !value : value);
    }

    protected abstract void ApplyNewValue(bool newValue);
  }
}
