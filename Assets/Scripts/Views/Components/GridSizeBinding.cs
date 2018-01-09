using System;
using Assets.Scripts.ViewModels.Properties;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views.Components
{
  class GridSizeBinding : MonoBehaviour
  {
    public Property<int> SizeX = new Property<int>();
    public Property<int> SizeY = new Property<int>();

    public string PathX;
    public string PathY;

    private GridLayoutGroup _grid;

    private void Start()
    {
      var view = FindObjectOfType<AppView>().GetView(transform);
      SizeX.Bind((IProperty<int>)view.ViewModel.GetType().GetField(PathX).GetValue(view.ViewModel));
      SizeY.Bind((IProperty<int>)view.ViewModel.GetType().GetField(PathY).GetValue(view.ViewModel));
      SizeX.OnChange += OnChange;
      SizeY.OnChange += OnChange;
      var rectTransform = gameObject.GetComponent<RectTransform>();
      _grid = gameObject.AddComponent<GridLayoutGroup>();
      _grid.cellSize = new Vector2(rectTransform.sizeDelta.x / SizeX.Value, rectTransform.sizeDelta.y / SizeY.Value);
    }

    private void OnChange(object sender, EventArgs e)
    {
      var rectTransform = gameObject.GetComponent<RectTransform>();
      _grid.cellSize = new Vector2(rectTransform.sizeDelta.x / SizeX.Value, rectTransform.sizeDelta.y / SizeY.Value);
    }

    public void OnDestroy()
    {
      SizeX.OnChange -= OnChange;
      SizeY.OnChange -= OnChange;
    }
  }
}
