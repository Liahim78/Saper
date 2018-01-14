using Assets.Scripts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels.Forms
{
  public class RecordsViewModel : SimpleViewModel
  {
    public void Back()
    {
      AppViewModel.AppView.OpenForm(FormType.MainForm);
    }
  }
}
