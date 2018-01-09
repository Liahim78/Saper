using System;

namespace Assets.Scripts.ViewModels.Properties
{
  public class Property<T> : IProperty<T>
  {
    private T value;

    public T Value { get { return value; } }

    public event EventHandler OnChange;

    public void Bind(IProperty<T> property)
    {
      value = property.Value;
      property.OnChange += Binding;
      OnChange += property.Binding;
    }

    public void Binding(object sender, EventArgs e)
    {
      value = ((BindingArgs<T>)e).Value;
    }

    public void Set(T value)
    {
      if (!value.Equals(Value))
        OnChange(this, new BindingArgs<T>(value));
      this.value = value;
    }
    
  }
}