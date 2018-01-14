using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ViewModels;
using Assets.Scripts.ViewModels.Properties;
using UnityEngine;
using System;

namespace Assets.Scripts.Views.Bindings
{
  public class ViewListBinding : BaseBinding
  {
    public string Path;

    public GameObject Prefab;

    private IEvent e;
    
    private IProperty _property;

    private Queue<GameObject> list = new Queue<GameObject>();
    private Queue<GameObject> listToDestroy = new Queue<GameObject>();

    private Func<List<IViewModel>> _getter;

    protected override void Unbind()
    {
      _getter = null;
      Unsubscribe(ref _property);
    }

    protected override void Bind()
    {
      _property = FindProperty(Path);
      if (_property == null) return;
        _getter = () => { return (_property as Property<List<IViewModel>>).Value; };
      _property.OnChange += OnChange;
    }


    protected override void OnChange()
    {
      var value = _getter();
      listToDestroy = list;
      list = new Queue<GameObject>();
      foreach (var item in value)
      {
        if (listToDestroy.Count > 0)
        {
          var prefab = listToDestroy.Dequeue();
          var view = prefab.GetComponent<ItemView>();
          view.Set(item);
          list.Enqueue(prefab);
        }
        else
        {
          var prefab = Instantiate(Prefab, CachedTransform);
          var view = prefab.GetComponent<ItemView>();
          view.Set(item);
          list.Enqueue(prefab);
        }
      }
      foreach (var item in listToDestroy)
        Destroy(item);
      base.OnChange();
    }
  }
}
