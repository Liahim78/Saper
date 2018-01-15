using System;
using Assets.Scripts.Views.Bindings;

namespace Assets.Scripts.ViewModels.Properties
{
  public class Property : IProperty
  {
    private object _value;

    public virtual object Value { get { return _value; } }

    public virtual event Action OnChange;

    public void Set(object value)
    {
      if (!value.Equals(Value) && OnChange != null)
        OnChange();
      _value = value;
    }

    public static void UpdateSubscriber(out Func<bool> getter, BooleanBinding.CheckTypes checkType, IProperty property,
      double reference, bool defaultValue)
    {
      getter = null;
      switch (checkType)
      {
        case BooleanBinding.CheckTypes.Boolean:
        {
          Property<bool> res;
          if (TryGetProperty(property, out res))
            getter = () => res.Value;
          break;
        }

        case BooleanBinding.CheckTypes.Empty:
        {
          Property<string> res;
          if (TryGetProperty(property, out res))
            getter = () => String.IsNullOrEmpty(res.Value);
          break;
        }

        case BooleanBinding.CheckTypes.EqualToReference:
        case BooleanBinding.CheckTypes.GreaterThanReference:
        case BooleanBinding.CheckTypes.LessThanReference:
        {
          Property<int> intProp;
          if (TryGetProperty(property, out intProp))
            getter = () => CompareReferences(intProp.Value, reference, checkType, defaultValue);
          break;
        }
      }
    }

    public static bool TryGetProperty<T>(IProperty p, out Property<T> result)
    {
      if (p != null)
      {
        result = p as Property<T>;
        return result != null;
      }

      result = null;
      return false;
    }

    private static bool CompareReferences(double value, double reference, BooleanBinding.CheckTypes checkType, bool defaultValue)
    {
      switch (checkType)
      {
        case BooleanBinding.CheckTypes.EqualToReference:
          return Math.Abs(value - reference) < 0.0001;

        case BooleanBinding.CheckTypes.GreaterThanReference:
          return value > reference;

        case BooleanBinding.CheckTypes.LessThanReference:
          return value < reference;
      }
      return defaultValue;
    }
  }

  public class Property<T>: Property, IProperty<T>
  {
    private T _value;

    public virtual T Value { get { return _value; } }

    public override event Action OnChange;

    public void Set(T value)
    {
      var previous = _value;
      _value = value;
      if (!value.Equals(previous) && OnChange != null)
        OnChange();
    }
    
    public void Invoke()
    {
      if (OnChange != null)
        OnChange();
    }

  }
}