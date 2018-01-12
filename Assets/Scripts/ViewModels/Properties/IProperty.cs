using System;

namespace Assets.Scripts.ViewModels.Properties
{
  public interface IProperty<T>
  {
    T Value { get; }

    event Action OnChange;
  }
}
