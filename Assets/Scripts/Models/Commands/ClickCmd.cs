using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models.Commands
{
  public class ClickCmd : ICommand
  {
    private readonly int _x;
    private readonly int _y;

    public ClickCmd(int x, int y)
    {
      _x = x;
      _y = y;
    }

    public void Execute()
    {
      AppModel.GetUser().Click(_x, _y);
    }
  }
}
