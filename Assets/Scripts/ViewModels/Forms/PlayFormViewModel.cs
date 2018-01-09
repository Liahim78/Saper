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

    public override void Initialize()
    {
      StartTime = DateTime.Now;
    }

    public override void Refresh()
    {
      SizeX.Set(AppModel.XSize);
      SizeY.Set(AppModel.YSize);
      CellItems.Set((new int[AppModel.XSize * AppModel.YSize]).Select((i, index) => new CellItemViewModel.Parametrs()
      {
        X = index % AppModel.XSize,
        Y = index / AppModel.XSize
      }));
      AllFlagCount.Set(AppModel.AllBombs);
      FlagCount.Set(AppModel.Flags.Count);
    }

    public override void RefreshOnNormilize()
    {
      Timer.Set((DateTime.Now - StartTime).ToString());
    }

  }
}
