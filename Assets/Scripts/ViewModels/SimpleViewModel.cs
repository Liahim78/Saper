using Assets.Scripts.ViewModels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Assets.Scripts.ViewModels
{
  public class SimpleViewModel : IViewModel
  {
    public Delegate FindMethod(string path)
    {
      var method = GetType().GetMethod(path);
      if (method == null)
        throw new Exception();

      var parameters = method.GetParameters();
      int paramsCount = parameters.Length;
      Type delegateType;
      switch (paramsCount)
      {
        case 1:
          delegateType = typeof(CommandArg<>).MakeGenericType(parameters[0].ParameterType);
          break;

        case 2:
          delegateType = typeof(CommandArgs<,>).MakeGenericType(parameters[0].ParameterType, parameters[1].ParameterType);
          break;

        default: // case 0
          delegateType = typeof(Command);
          break;
      }

      return Delegate.CreateDelegate(delegateType, this, method);
    }
    
    public IProperty FindProperty(string path)
    {
      var field = GetType().GetField(path);
      if (field == null)
        throw new Exception();
      return field.GetValue(this) as IProperty;
    }

    public virtual void OnDestroy()
    {
    }
  }
}
