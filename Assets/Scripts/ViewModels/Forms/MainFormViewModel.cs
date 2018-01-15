using Assets.Scripts.Models.Commands;
using Assets.Scripts.Views;
using Assets.Scripts.Views.Popups;

namespace Assets.Scripts.ViewModels
{
  public class MainFormViewModel : SimpleViewModel
  {
    public void Play()
    {
      AppViewModel.AppView.OpenPopup(PopupType.ChooseDificultPopup);
    }

    public void Records()
    {
      AppViewModel.AppView.OpenForm(FormType.RecordsForm);
    }
  }
}
