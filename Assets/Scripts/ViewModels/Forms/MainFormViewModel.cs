using Assets.Scripts.Models;
using Assets.Scripts.Models.Commands;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.ViewModels
{
  public class MainFormViewModel : SimpleViewModel
  {
    public void Play()
    {
      new CreateGameCmd(8,8,10).Execute();
      AppViewModel.AppView.OpenForm(FormType.PlayForm);
    }

    public void Records()
    {
      AppViewModel.AppView.OpenForm(FormType.RecordsForm);
    }
  }
}
