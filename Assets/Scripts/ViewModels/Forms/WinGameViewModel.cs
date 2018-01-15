using Assets.Scripts.Models.Commands;
using Assets.Scripts.ViewModels.Properties;
using Assets.Scripts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Models;

namespace Assets.Scripts.ViewModels.Forms
{
  public class WinGameViewModel : RefreshableViewModel
  {
    public readonly Property<string> Time = new Property<string>();
    public readonly Property<string> Name = new Property<string>();

    public void Back()
    {
      new AddRecordCmd(Name.Value).Execute();
      new FinishGameCmd().Execute();
      AppViewModel.AppView.OpenForm(FormType.MainForm);
    }

    public override void Refresh(User user)
    {
      Time.Set((user.FinishTime - user.StartTime).ToString());
      var rand = new Random();
      base.Refresh(user);
    }
  }
}
