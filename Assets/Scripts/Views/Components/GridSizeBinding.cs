using Assets.Scripts.ViewModels.Properties;
using UnityEngine.UI;

namespace Assets.Scripts.Views.Components
{
  class GridSizeBinding : GridLayoutGroup
  {
    public Property<int> SizeX = new Property<int>();
    public Property<int> SizeY = new Property<int>();

    public string PathX;
    public string PathY;

    public void OnStart()
    {
      var view = FindObjectOfType<AppView>().GetView(transform);
      SizeX.Bind((IProperty<int>)view.ViewModel.GetType().GetField(PathX).GetValue(view.ViewModel));
      SizeY.Bind((IProperty<int>)view.ViewModel.GetType().GetField(PathY).GetValue(view.ViewModel));
      //cellSize = new Vector2(transform)
    }

  }
}
