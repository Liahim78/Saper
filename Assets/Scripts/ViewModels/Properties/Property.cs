using System;

namespace Assets.Scripts.ViewModels.Properties
{
  public class Property<T> : IProperty<T>
  {
    private T value;

    public T Value { get { return value; } }

    public event Action OnChange;
    

    public void Set(T value)
    {
      if (!value.Equals(Value) && OnChange != null)
        OnChange();
      this.value = value;
    }
    
    public void Invoke()
    {
      if (OnChange != null)
        OnChange();
    }

  }
}