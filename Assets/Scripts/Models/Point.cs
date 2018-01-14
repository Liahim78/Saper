using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
  public class Point
  {
    public int I { get; set; }
    public int J { get; set; }

    public Point()
    {

    }

    public Point(int i, int j)
    {
      I = i;
      J = j;
    }

    public override bool Equals(object obj)
    {
      var point = obj as Point;
      return point != null && point.I == I && point.J == J;
    }

    public override int GetHashCode()
    {
      return I * J;
    }
  }
}
