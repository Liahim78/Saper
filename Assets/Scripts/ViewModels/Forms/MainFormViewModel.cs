using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.ViewModels
{
  public class MainFormViewModel : SimpleViewModel
  {
    public void Play()
    {
      AppViewModel.AppView.OpenForm(FormType.PlayForm);
    }
  }
}
