using System;

namespace Assets.Scripts.Views.Bindings
{
  public class CommandBinding : BaseBinding
  {
    public string Path;

    private Delegate _command;

    public bool Binded { get { return _command != null; } }

    protected override void Unbind()
    {
      _command = null;
    }

    protected override void Bind()
    {
      _command = FindMethod(Path);
    }

    public void InvokeCommand()
    {
      if (_command != null)
        _command.DynamicInvoke();
    }

    public void InvokeCommandWithArgs(params object[] values)
    {
      if (_command != null)
        _command.DynamicInvoke(values);
    }
  }
}
