using System;

namespace Assets.Scripts.ViewModels.Properties
{
  public interface IProperty
  {
    object Value { get; }

    event Action OnChange;
  }

  public interface IProperty<T> : IProperty
  {
    T Value { get; }

    event Action OnChange;
  }
}
