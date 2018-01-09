
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

    private static int SetCountBombsAround(int i, int j)
    {
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
      foreach (var item in AppViewModel.RefreshableViewModels)
      {
        item.Refresh();
      }
    }
  }
}
