using Assets.Scripts.ViewModels;
using Assets.Scripts.ViewModels.Forms;
using Assets.Scripts.ViewModels.Properties;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Views.Components
{
  public class ViewListBinding : MyComponent
  {
    public string PathList;
    public GameObject Prefab;

    private IEvent e;

    private Queue<GameObject> list = new Queue<GameObject>();
    private Queue<GameObject> listToDestroy = new Queue<GameObject>();


    private void Start()
    {
      var viewModel = FindObjectOfType<AppView>().GetView(transform).ViewModel;
      e = viewModel.GetType().GetField(PathList).GetValue(viewModel) as IEvent;
      e.OnChange += Change;
      Change();
    }

    protected override void OnChange()
    {
      listToDestroy = list;
      list = new Queue<GameObject>();
      var viewModel = FindObjectOfType<AppView>().GetView(transform).ViewModel;
      foreach (IViewModel item in viewModel.GetType().GetField(PathList).GetValue(viewModel) as IEnumerable)
      {
        GameObject gameobject;
        if (listToDestroy.Count > 0)
        {
          gameobject = listToDestroy.Dequeue();
          var itemView = gameobject.GetComponent<ItemView>();
          itemView.ViewModel.OnDestroy();
          itemView.Set(item);
        }
        else
        {
          gameobject = Instantiate(Prefab, transform);
          var itemView = gameobject.AddComponent<ItemView>();
          itemView.Set(item);
        }
        list.Enqueue(gameobject);
      }
      foreach (var item in listToDestroy)
        Destroy(item);
      listToDestroy = new Queue<GameObject>();
    }
    public void OnDestroy()
    {
      e.OnChange -= Change;
    }
  }
}
