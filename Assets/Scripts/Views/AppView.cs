using UnityEngine;

namespace Assets.Scripts.Views
{
  public class AppView:MonoBehaviour
  {
    private AppView instance;

    public AppView Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new AppView();
        }
        return instance;
      }
    }

    public GameObject Form;
    public GameObject Popups;

    // Use this for initialization
    void Start()
    {
      OpenForm(FormType.MainForm);
    }

    private AppView()
    {

    }
    public void OpenForm(FormType formType, object state = null)
    {
      var prefab = (GameObject)Resources.Load(@"Forms/"+formType.ToString(), typeof(GameObject));
      if (prefab == null)
      {
        Debug.LogError("Prefab" + formType.ToString() + "is null");
        return;
      }

      Instantiate(prefab, Form.transform);
    }
  }
}
