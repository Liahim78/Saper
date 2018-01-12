using Assets.Scripts.ViewModels.Properties;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Views.Components
{
  public class DictionarySpriteBinding : MyComponent
  {
    public string Path;
    public Property<int> IconIndex = new Property<int>();
    public Image Image;

    public int[] Indexes;
    public Sprite[] Imagies;

    private void Start()
    {
      var view = FindObjectOfType<AppView>().GetView(transform);
      IconIndex = view.ViewModel.GetType().GetField(Path).GetValue(view.ViewModel) as Property<int>;
      IconIndex.OnChange += Change;
      Change();
    }
    
    protected override void OnChange()
    {
      var index = Indexes.Where(item => item == IconIndex.Value).Select((item, i) => i).First();
      Image.sprite = Imagies[index];
    }

    public void OnDestroy()
    {
      IconIndex.OnChange -= Change;
    }
  }
}
