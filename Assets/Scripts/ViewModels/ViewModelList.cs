using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.ViewModels
{
  public class ViewModelList<T, R> : IEnumerable<T> where T : ISettable<R>, new()
  {
    private readonly List<T> list = new List<T>();
    public IEnumerator<T> GetEnumerator()
    {
      return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return list.GetEnumerator();
    }
    
    public void Set(IEnumerable<R> list)
    {
      this.list.Clear();
      foreach (var item in list)
      {
        var viewModel = new T();
        viewModel.Set(item);
        this.list.Add(viewModel);
      }
    }
  }
}
