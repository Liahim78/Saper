using Assets.Scripts.ViewModels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels.Forms
{
  public class RecordItemViewModel:SimpleViewModel, ISettable<RecordItemViewModel.Parametrs>
  {
    public class Parametrs
    {
      public string name;
      public TimeSpan time;

      public Parametrs(string name, TimeSpan time)
      {
        this.name = name;
        this.time = time;
      }
    }

    private string _name;
    private TimeSpan _time;

    public readonly Property<string> Name = new Property<string>();
    public readonly Property<string> Time = new Property<string>();
    public bool Equal(Parametrs parametrs)
    {
      return _name == parametrs.name && _time == parametrs.time;
    }

    public void Set(Parametrs value)
    {
      _name = value.name;
      _time = value.time;
      Name.Set(_name);
      Time.Set(_time.ToString());
    }

  }
}
