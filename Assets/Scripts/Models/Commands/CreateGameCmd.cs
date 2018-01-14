using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models.Commands
{
  public class CreateGameCmd : ICommand
  {
    private readonly int _sizeX;
    private readonly int _sizeY;
    private readonly int _bombsCount;

    public CreateGameCmd(int sizeX, int sizeY, int bombsCount)
    {
      _sizeX = sizeX;
      _sizeY = sizeY;
      _bombsCount = bombsCount;
    }

    public void Execute()
    {
      AppModel.GetUser().CreateGame(_sizeX, _sizeY, _bombsCount);
    }
  }
}
