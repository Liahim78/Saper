using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models.Commands
{
  public class AddRecordCmd : ICommand
  {
    private Record record;

    public AddRecordCmd(string name)
    {
      var user = AppModel.GetUser();
      record = new Record(name, user.FinishTime - user.StartTime);
    }
    public void Execute()
    {
      AppModel.GetUser().Records.Add(record);
    }
  }
}
