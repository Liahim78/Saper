using Assets.Scripts.ViewModels;
using Assets.Scripts.ViewModels.Forms;
using Assets.Scripts.ViewModels.Properties;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Views.Components
{
  public class ViewListBinding : MonoBehaviour
  {
    public string PathList;
    public GameObject Prefab;

    private IEvent e;

    private void Start()
    {
      var viewModel = FindObjectOfType<AppView>().GetView(transform).ViewModel;
      e = viewModel.GetType().GetField(PathList).GetValue(viewModel) as IEvent;
      e.OnChange += OnChange;
      OnChange();
    }

    private void OnChange()
    {
      var viewModel = FindObjectOfType<AppView>().GetView(transform).ViewModel;
      foreach (IViewModel item in viewModel.GetType().GetField(PathList).GetValue(viewModel) as IEnumerable)
      {
        var gameobject = Instantiate(Prefab, transform);
        var itemView = gameobject.AddComponent<ItemView>();
        itemView.Set(item);
      }
    }
    public void OnDestroy()
    {
      e.OnChange -= OnChange;
    }
  }
}
