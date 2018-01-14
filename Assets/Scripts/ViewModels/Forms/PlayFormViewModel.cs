using Assets.Scripts.Models;
using Assets.Scripts.ViewModels.Properties;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.ViewModels.Forms
{
  public class PlayFormViewModel: RefreshableViewModel
  {
    public readonly ViewModelList<CellItemViewModel, CellItemViewModel.Parametrs> CellItems = new ViewModelList<CellItemViewModel, CellItemViewModel.Parametrs>();
    public readonly Property<int> SizeX = new Property<int>();
    public readonly Property<int> SizeY = new Property<int>();
    public readonly Property<int> FlagCount = new Property<int>();
    public readonly Property<int> AllFlagCount = new Property<int>();
    public readonly Property<string> Timer = new Property<string>();

    private DateTime StartTime;

    public override void Subscribe(User user)
    {
      user.OnChange += Refresh;
      AppModel.OnNormalize += Normolize;
    }

    public override void Instantiate(User user)
    {
      StartTime = DateTime.Now;
    }

    public override void Refresh(User user)
    {
      SizeX.Set(user.XSize);
      SizeY.Set(user.YSize);
      CellItems.Set((new int[user.XSize * user.YSize]).Select((i, index) => new CellItemViewModel.Parametrs()
      {
        X = index % user.XSize,
        Y = index / user.XSize
      }).ToList());
      AllFlagCount.Set(user.AllBombs);
      FlagCount.Set(user.Flags.Count);
    }

    public override void Normolize(User user)
    {
      Timer.Set((DateTime.Now - StartTime).ToString());
    }

  }
}
