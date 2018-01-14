using Assets.Scripts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ViewModels
{
  public interface IRefreshableViewModel
  {
    void Instantiate(User user);
    void Subscribe(User user);
    void Refresh(User user);
    void Normolize(User user);
  }
}
