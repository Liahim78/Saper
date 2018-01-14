using Assets.Scripts.Models;

namespace Assets.Scripts.ViewModels
{
  public class RefreshableViewModel : SimpleViewModel, IRefreshableViewModel
  {
    public RefreshableViewModel():
      this(false)
    {
    }
    public RefreshableViewModel(bool flag)
    {
      if (flag)
        return;
      OnBegin();
    }

    protected void OnBegin()
    {
      User user = AppModel.GetUser();
      Instantiate(user);
      Subscribe(user);
      Refresh(user);
    }

    public virtual void Refresh(User user)
    {

    }
    
    public override void OnDestroy()
    {
      AppViewModel.RemoveRefresh(this);
    }

    public virtual void Instantiate(User user)
    {
    }

    public virtual void Subscribe(User user)
    {
    }

    public virtual void Normolize(User user)
    {
    }
  }
}