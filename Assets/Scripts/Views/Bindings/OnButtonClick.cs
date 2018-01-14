namespace Assets.Scripts.Views.Bindings
{
  public class OnButtonClick: CommandBinding, IClick
  {
    // ReSharper disable once UnusedMember.Local
    protected virtual void OnClick()
    {
      InvokeCommand();
    }

    public void Click()
    {
      OnClick();
    }
  }
}
