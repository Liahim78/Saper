namespace Assets.Scripts.ViewModels
{
  public class RefreshableViewModel : IViewModel
  {
    public RefreshableViewModel()
    {
      AppViewModel.RefreshableViewModels.Add(this);
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
  }
}