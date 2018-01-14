using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Views
{
  public class InstantiateInitController : MonoBehaviour
  {
    private readonly static List<IInstantiateInitable> List1 = new List<IInstantiateInitable>();
    private readonly static List<IInstantiateInitable> List2 = new List<IInstantiateInitable>();

    private static List<IInstantiateInitable> _currentList;
    private static bool _runningInstantiate;

    static InstantiateInitController()
    {
      _currentList = List1;
    }

    public static void AddToInit(IInstantiateInitable instantiateObj)
    {
      _currentList.Add(instantiateObj);
    }

    public static void InitAndClear()
    {
      if (_runningInstantiate)
        return;

      _runningInstantiate = true;

      while (_currentList.Count > 0)
      {
        var tempList = _currentList;
        _currentList = _currentList == List1 ? List2 : List1;
        _currentList.Clear();

        if (tempList == _currentList)
          throw new InvalidOperationException();

        foreach (var behaviour in tempList)
        {
          if (!behaviour.Equals(null))
            behaviour.InstantiateInit();
        }

        tempList.Clear();
      }

      _runningInstantiate = false;
    }

    protected void Update()
    {
      InitAndClear();
    }
  }
}