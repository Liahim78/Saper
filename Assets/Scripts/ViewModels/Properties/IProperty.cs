using System;

namespace Assets.Scripts.ViewModels.Properties
{
  public interface IProperty<T>
  {
    T Value { get; }

    event EventHandler OnChange;

    void Bind(IProperty<T> property);

    void Binding(object sender, EventArgs e);
  }
}
