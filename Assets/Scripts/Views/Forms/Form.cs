using Assets.Scripts.ViewModels;
using UnityEngine;

namespace Assets.Scripts.Views
{
  public class Form<T> : ItemView where T : IViewModel, new()
  {
    void Awake()
    {
      Set(new T());
    }
  }
}
