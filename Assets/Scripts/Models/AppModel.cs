
using Assets.Scripts.ViewModels;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Models
{
  public static class AppModel
  {
    private static int[,] gameZone;
    private static bool[,] openedZone;
    public static readonly  Dictionary<int, int> Flags = new Dictionary<int, int>();
    public static int AllBombs;
    public static int XSize;
    public static int YSize;

    public static void CreateGame(int sizeX, int sizeY, int bombsCount)
    {
      gameZone = new int[sizeY, sizeX];
      openedZone = new bool[sizeY, sizeX];
      XSize = sizeX;
      YSize = sizeY;
      SetBombs(bombsCount);
      for (int i = 0; i < gameZone.GetLength(0); i++)
      {
        for (int j = 0; j < gameZone.GetLength(1); j++)
        {
          gameZone[i, j] = SetCountBombsAround(i, j);
        }
      }
      RefreshViewModel();
    }

    public static int GetGameZone(int x, int y)
    {
      return gameZone[y, x];
    }

    public static bool GetOpenedZone(int x, int y)
    {
      return openedZone[y, x];
    }

    private static int SetCountBombsAround(int i, int j)
    {
      if (gameZone[i, j] == -1)
        return -1;
      var countAround = 0;
      if (i - 1 >= 0 && gameZone[i - 1, j] == -1) countAround++;
      if (j - 1 >= 0 && gameZone[i, j - 1] == -1) countAround++;
      if (j - 1 >= 0 && i - 1 >= 0 && gameZone[i - 1, j - 1] == -1) countAround++;
      if (j - 1 >= 0 && i + 1 < gameZone.GetLength(0) && gameZone[i + 1, j - 1] == -1) countAround++;
      if (i - 1 >= 0 && j + 1 < gameZone.GetLength(1) && gameZone[i - 1, j + 1] == -1) countAround++;
      if (j + 1 < gameZone.GetLength(1) && gameZone[i, j + 1] == -1) countAround++;
      if (i + 1 < gameZone.GetLength(0) && gameZone[i + 1, j] == -1) countAround++;
      if (i + 1 < gameZone.GetLength(0) && j + 1 < gameZone.GetLength(1) && gameZone[i + 1, j + 1] == -1) countAround++;
      return countAround;
    }

    private static void SetBombs(int count)
    {
      AllBombs = count;
      int bombs = 0;
      var rand = new Random();
      while (bombs < count)
      {
        var i = rand.Next(gameZone.GetLength(0));
        var j = rand.Next(gameZone.GetLength(1));
        if (gameZone[i, j] == -1)
          continue;
        gameZone[i, j] = -1;
        bombs++;
      }
    }

    private static void RefreshViewModel()
    {
      foreach (var item in AppViewModel.GetRefresh())
        item.Refresh();
    }

    public static void OnClick(int x, int y)
    {
      Click(x, y);
      RefreshViewModel();
    }

    private static void Click(int x, int y)
    {
      if (y >= gameZone.GetLength(0) || y < 0)
        return;
      if (x >= gameZone.GetLength(1) || x < 0)
        return;
      if (openedZone[y, x] == true)
        return;
      openedZone[y, x] = true;
      if (gameZone[y, x] == 0)
      {
        Click(x, y - 1);
        Click(x-1, y - 1);
        Click(x+1, y - 1);
        Click(x, y + 1);
        Click(x-1, y + 1);
        Click(x+1, y + 1);
        Click(x-1, y);
        Click(x+1, y);
      }
    }
  }
}
