
using Assets.Scripts.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Assets.Scripts.Models
{
  public static class AppModel
  {
    private static User user;

    public static Thread NormalizationThread;

    public static event Action<User> OnNormalize;

    static AppModel()
    {
      user = new User();
      NormalizationThread = new Thread(Normalization);
      NormalizationThread.Start();
    }

    private static void Normalization()
    {
      Debug.Log("Normalize " + DateTime.Now);
      if (OnNormalize != null)
        OnNormalize(user);
      Thread.Sleep(1000);
      Normalization();
    }
    
    public static User GetUser()
    {
      return user;
    }
        
  }
}
