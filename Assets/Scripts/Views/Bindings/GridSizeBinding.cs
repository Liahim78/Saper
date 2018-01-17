using Assets.Scripts.ViewModels.Properties;
using Assets.Scripts.Views.Bindings;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views.Components
{
  class GridSizeBinding : BaseBinding
  {
    private IProperty _sizeX;
    private IProperty _sizeY;

    public string PathX;
    public string PathY;
    
    private Func<int> _getterSizeX;
    private Func<int> _getterSizeY;

    protected override void OnStart()
    {
      var grid = CachedGameObj.AddComponent<GridLayoutGroup>();
      grid.childAlignment = TextAnchor.MiddleCenter;
      base.OnStart();
    }

    protected override void Unbind()
    {
      _getterSizeX = null;
      _getterSizeY = null;
      Unsubscribe(ref _sizeX);
      Unsubscribe(ref _sizeY);
    }

    protected override void Bind()
    {
      _sizeX = FindProperty(PathX);
      _sizeY = FindProperty(PathY);
      if (_sizeX == null || _sizeY == null) return;
      _getterSizeX = () => { return (_sizeX as Property<int>).Value; };
      _getterSizeY = () => { return (_sizeY as Property<int>).Value; };
      _sizeX.OnChange += OnChange;
      _sizeY.OnChange += OnChange;
    }


    protected override void OnChange()
    {
      var rectTransform = gameObject.GetComponent<RectTransform>();
      var grid = CachedGameObj.GetComponent<GridLayoutGroup>();
      var size = Math.Min(rectTransform.rect.width / _getterSizeX(), rectTransform.rect.height / _getterSizeY());
      if (grid != null)
        grid.cellSize = new Vector2(size, size);
      base.OnChange();
    }
  }
}
