using Assets.Scripts.Models.Commands;
using Assets.Scripts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels.Forms
{
  public class LoseGameViewModel : SimpleViewModel
  {
    public void Back()
    {
      new FinishGameCmd().Execute();
      AppViewModel.AppView.OpenForm(FormType.MainForm);
    }
  }
}
