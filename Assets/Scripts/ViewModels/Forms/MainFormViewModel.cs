using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.ViewModels
{
  public class MainFormViewModel : SimpleViewModel
  {
    public void Play()
    {
      AppModel.CreateGame(8, 8, 10);
      AppViewModel.AppView.OpenForm(FormType.PlayForm);
    }
  }
}
