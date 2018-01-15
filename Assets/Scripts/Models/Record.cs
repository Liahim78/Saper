using System;

namespace Assets.Scripts.Models
{
  public class Record
  {
    public string Name { get; set; }

    public TimeSpan Time { get; set; }

    public Record()
    {

    }

    public Record(string name, TimeSpan time)
    {
      Name = name;
      Time = time;
    }
  }
}