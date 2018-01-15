using Assets.Scripts.Models.Commands;
using Assets.Scripts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels.Forms
{
  public class ChooseDificultPopupViewModel : SimpleViewModel
  {
    public void Easy()
    {
      new CreateGameCmd(8, 8, 10).Execute();
      AppViewModel.AppView.OpenForm(FormType.PlayForm);
    }

    public void Middle()
    {
      new CreateGameCmd(17, 17, 50).Execute();
      AppViewModel.AppView.OpenForm(FormType.PlayForm);
    }

    public void Hard()
    {
      new CreateGameCmd(23, 23, 100).Execute();
      AppViewModel.AppView.OpenForm(FormType.PlayForm);
    }
  }
}
