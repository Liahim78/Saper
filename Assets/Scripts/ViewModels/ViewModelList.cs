using Assets.Scripts.ViewModels.Properties;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.ViewModels
{
  public class ViewModelList<T, R> : Property<List<IViewModel>> where T : ISettable<R>, IViewModel, new()
  {
    public override event Action OnChange;

    private readonly List<IViewModel> list = new List<IViewModel>();

    public override List<IViewModel> Value
    {
      get
      {
        return list;
      }
    }

    public void Set(IList<R> list)
    {
      if (Equals(list))
        return;
      Value.Clear();
      foreach (var item in list)
      {
        var viewModel = new T();
        viewModel.Set(item);
        Value.Add(viewModel);
      }
      if (OnChange!= null)
        OnChange();
    }

    private bool Equals(IList<R> list)
    {
      if (list.Count != this.list.Count)
        return false;
      var result = true;
      for (int i = 0; i < this.list.Count; i++)
      {
        if (!this.list[i].Equals(list[i]))
          return false;
      }
      return result;
    }
  }
}
