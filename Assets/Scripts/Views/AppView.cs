using Assets.Scripts.ViewModels;
using UnityEngine;

namespace Assets.Scripts.Views
{
  public class AppView:MonoBehaviour
  {
    public GameObject Form;
    public GameObject Popups;

    private GameObject OpenedForm;
    private GameObject OpenedPopup;

    // Use this for initialization
    void Start()
    {
      AppViewModel.AppView = this;
      OpenForm(FormType.MainForm);
    }

    private AppView()
    {

    }
    public void OpenForm(FormType formType, object state = null)
    {
      if (OpenedForm != null)
      {
        Destroy(OpenedForm);
      }
      var prefab = (GameObject)Resources.Load(@"Forms/"+formType.ToString(), typeof(GameObject));
      if (prefab == null)
      {
        Debug.LogError("Prefab" + formType.ToString() + "is null");
        return;
      }
      OpenedForm = Instantiate(prefab, Form.transform);
    }

    public IView GetView(Transform transform)
    {
      var current = transform;
      var view = current.GetComponent<IView>();
      while (view == null && current.parent != null)
      {
        current = current.parent;
        view = current.GetComponent<IView>();
      }
      return view;
    }
  }
}
