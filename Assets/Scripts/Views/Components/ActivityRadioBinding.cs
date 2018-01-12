using Assets.Scripts.ViewModels.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Views.Components
{
  public class ActivityRadioBinding : MyComponent
  {
    public string Path;

    public GameObject[] GameObjects;

    public Property<int> ActivityIndex = new Property<int>();

    private void Start()
    {
      var view = FindObjectOfType<AppView>().GetView(transform);
      ActivityIndex = view.ViewModel.GetType().GetField(Path).GetValue(view.ViewModel) as Property<int>;
      ActivityIndex.OnChange += Change;
      Change();
    }


    protected override void OnChange()
    {
      foreach (var item in GameObjects)
        item.SetActive(false);
      GameObjects[ActivityIndex.Value].SetActive(true);
    }

    public void OnDestroy()
    {
      ActivityIndex.OnChange -= Change;
    }
  }
}
