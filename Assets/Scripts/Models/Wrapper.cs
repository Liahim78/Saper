using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
  public class Wrapper<T>
  {
    private T myValue;

    public event Action<User> OnChange;

    public T Value
    {
      get { return myValue; }
      set
      {
        myValue = value;
        if (OnChange!= null)
          OnChange(AppModel.GetUser());
      }
    }

    public Wrapper()
    {

    }

    public Wrapper(T value)
    {
      this.myValue = value;
    }
  }
}
