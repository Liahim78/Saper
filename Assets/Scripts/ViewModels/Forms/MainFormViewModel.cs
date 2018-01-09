using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.ViewModels
{
  public class MainFormViewModel : SimpleViewModel
  {
    public void Play()
    {
      AppModel.CreateGame(20, 20, 50);
      AppViewModel.AppView.OpenForm(FormType.PlayForm);
    }
  }
}
