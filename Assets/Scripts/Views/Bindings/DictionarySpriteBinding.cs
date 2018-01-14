using Assets.Scripts.ViewModels.Properties;
using Assets.Scripts.Views.Bindings;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views.Components
{
  public class DictionarySpriteBinding : BaseBinding
  {
    public string Path;
    public Image Image;

    public int[] Indexes;
    public Sprite[] Imagies;

    private Dictionary<int, Sprite> _dictionary = new Dictionary<int, Sprite>();

    private IProperty _property;

    private Func<int> _getter;

    protected override void OnStart()
    {
      for (int i = 0; i < Indexes.Length; i++)
        _dictionary.Add(Indexes[i], Imagies[i]);
      
      base.OnStart();
    }

    protected override void Unbind()
    {
      _getter = null;
      Unsubscribe(ref _property);
    }

    protected override void Bind()
    {
      _property = FindProperty(Path);
      if (_property == null) return;
      _getter = () => { return (_property as Property<int>).Value; };
      _property.OnChange += OnChange;
    }
    
    protected override void OnChange()
    {
      Image.sprite = _dictionary[_getter()];
      base.OnChange();
    }
  }
}
