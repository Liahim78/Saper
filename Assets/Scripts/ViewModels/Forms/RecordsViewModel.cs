using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels.Forms
{
  public class RecordsViewModel : SimpleViewModel
  {
    public readonly ViewModelList<RecordItemViewModel, RecordItemViewModel.Parametrs> Records = new ViewModelList<RecordItemViewModel, RecordItemViewModel.Parametrs>();

    public void Back()
    {
      AppViewModel.AppView.OpenForm(FormType.MainForm);
    }

    public RecordsViewModel()
    {
      var user = AppModel.GetUser();
      Records.Set(user.Records.Select(item => new RecordItemViewModel.Parametrs(item.Name, item.Time)).ToList());
    }
  }
}
