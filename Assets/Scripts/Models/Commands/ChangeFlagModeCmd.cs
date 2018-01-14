using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models.Commands
{
  public class ChangeFlagModeCmd : ICommand
  {
    public void Execute()
    {
      var user = AppModel.GetUser();
      user.FlagMode.Value = !user.FlagMode.Value;
    }
  }
}
