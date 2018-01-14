using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
  public class User 
  {
    private Wrapper<int>[,] gameZone;
    private Wrapper<bool>[,] openedZone;
    public readonly Dictionary<int, int> Flags = new Dictionary<int, int>();
    public int AllBombs;
    public int XSize;
    public int YSize;

    private bool _setBombs = false;
    
    public event Action<User> OnChange;

    public void CreateGame(int sizeX, int sizeY, int bombsCount)
    {
      gameZone = new Wrapper<int>[sizeY, sizeX];
      openedZone = new Wrapper<bool>[sizeY, sizeX];
      for (int i = 0; i < sizeY; i++)
      {
        for (int j = 0; j < sizeX; j++)
        {
          gameZone[i, j] = new Wrapper<int>(0);
          openedZone[i, j] = new Wrapper<bool>(false);
        }
      }
      XSize = sizeX;
      YSize = sizeY;
      AllBombs = bombsCount;
      Change();
    }

    private void Change()
    {
      if (OnChange != null)
        OnChange(this);
    }

    public Wrapper<int> GetGameZone(int x, int y)
    {
      return gameZone[y, x];
    }

    public Wrapper<bool> GetOpenedZone(int x, int y)
    {
      return openedZone[y, x];
    }

    public void Click(int x, int y)
    {
      if (!_setBombs)
      {
        SetBombs(AllBombs, x, y);
        for (int i = 0; i < gameZone.GetLength(0); i++)
          for (int j = 0; j < gameZone.GetLength(1); j++)
            gameZone[i,j].Value = SetCountBombsAround(i, j);
      }
      NextClick(x, y);
      _setBombs = true;
    }

    private void NextClick(int x, int y)
    {
      if (y >= gameZone.GetLength(0) || y < 0)
        return;
      if (x >= gameZone.GetLength(1) || x < 0)
        return;
      if (openedZone[y, x].Value == true)
        return;
      openedZone[y, x].Value = true;
      if (gameZone[y, x].Value == 0)
      {
        NextClick(x, y - 1);
        NextClick(x - 1, y - 1);
        NextClick(x + 1, y - 1);
        NextClick(x, y + 1);
        NextClick(x - 1, y + 1);
        NextClick(x + 1, y + 1);
        NextClick(x - 1, y);
        NextClick(x + 1, y);
      }
    }

    private int SetCountBombsAround(int i, int j)
    {
      if (gameZone[i, j].Value == -1)
        return -1;
      var countAround = 0;
      if (i - 1 >= 0 && gameZone[i - 1, j].Value == -1) countAround++;
      if (j - 1 >= 0 && gameZone[i, j - 1].Value == -1) countAround++;
      if (j - 1 >= 0 && i - 1 >= 0 && gameZone[i - 1, j - 1].Value == -1) countAround++;
      if (j - 1 >= 0 && i + 1 < gameZone.GetLength(0) && gameZone[i + 1, j - 1].Value == -1) countAround++;
      if (i - 1 >= 0 && j + 1 < gameZone.GetLength(1) && gameZone[i - 1, j + 1].Value == -1) countAround++;
      if (j + 1 < gameZone.GetLength(1) && gameZone[i, j + 1].Value == -1) countAround++;
      if (i + 1 < gameZone.GetLength(0) && gameZone[i + 1, j].Value == -1) countAround++;
      if (i + 1 < gameZone.GetLength(0) && j + 1 < gameZone.GetLength(1) && gameZone[i + 1, j + 1].Value == -1) countAround++;
      return countAround;
    }

    private void SetBombs(int count, int x = -1, int y = -1)
    {
      int bombs = 0;
      var rand = new Random();
      while (bombs < count)
      {
        var i = rand.Next(gameZone.GetLength(0));
        var j = rand.Next(gameZone.GetLength(1));
        if (i == y && j == x) continue;
        if (gameZone[i, j].Value == -1)
          continue;
        gameZone[i, j].Value = -1;
        bombs++;
      }
    }

  }
}
