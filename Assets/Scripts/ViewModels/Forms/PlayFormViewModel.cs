using Assets.Scripts.Models;
using Assets.Scripts.Models.Commands;
using Assets.Scripts.ViewModels.Properties;
using Assets.Scripts.Views;
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
    public readonly Property<bool> IsFlag = new Property<bool>();
    public readonly Property<string> FlagCount = new Property<string>();
    public readonly Property<string> Timer = new Property<string>();

    public override void Subscribe(User user)
    {
      user.OnChange += Refresh;
      user.FlagMode.OnChange += SetFlagMode;
      user.Flags.OnChange += SetFlagCount;
      AppModel.OnNormalize += Normolize;
    }

    public override void Refresh(User user)
    {
      SizeX.Set(user.XSize.Value);
      SizeY.Set(user.YSize.Value);
      CellItems.Set((new int[user.XSize.Value * user.YSize.Value]).Select((i, index) => new CellItemViewModel.Parametrs()
      {
        X = index % user.XSize.Value,
        Y = index / user.XSize.Value
      }).ToList());
      SetFlagCount(user);
      SetFlagMode(user);
    }

    private void SetFlagMode(User user)
    {
      IsFlag.Set(user.FlagMode.Value);
    }

    private void SetFlagCount(User user)
    {
      FlagCount.Set(string.Format("{0}/{1}", user.Flags.Count, user.AllBombs.Value));
    }

    public override void Normolize(User user)
    {
      var timer = user.FinishTime - user.StartTime;
      Timer.Set(string.Format("{0}:{1}:{2}",timer.Hours, timer.Minutes, timer.Seconds));
    }

    public void ChangeFlagMode()
    {
      new ChangeFlagModeCmd().Execute();
    }

    public void Back()
    {
      new FinishGameCmd().Execute();
      AppViewModel.AppView.OpenForm(FormType.MainForm);
    }
  }
}
