namespace Assets.Scripts.ViewModels
{
  public class RefreshableViewModel : IViewModel
  {
    public RefreshableViewModel()
    {
      AppViewModel.AddRefresh(this);
      Initialize();
      Refresh();
    }

    public virtual void Initialize()
    {

    }

    public virtual void Refresh()
    {

    }

    public virtual void RefreshOnNormilize()
    {

    }

    public void OnDestroy()
    {
      AppViewModel.RemoveRefresh(this);
    }

  }
}