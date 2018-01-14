using Assets.Scripts.ViewModels;

namespace Assets.Scripts.Views.Popups
{
  public class Popup<T> : ItemView where T : IViewModel, new()
  {
    void Awake()
    {
      Set(new T());
    }
  }
}
