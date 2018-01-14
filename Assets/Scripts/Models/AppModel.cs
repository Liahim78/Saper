using System;
using System.Threading;

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
