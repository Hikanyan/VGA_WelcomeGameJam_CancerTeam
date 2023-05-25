using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : AbstractSingleton<SequenceManager>
{
    [SerializeField]
    GameObject[] _preloadedAssets;
    public void Initialize()
    {
        InstantiatePreloadedAssets();
    }
    void InstantiatePreloadedAssets()
    {
        foreach (var asset in _preloadedAssets)
        {
            Instantiate(asset);
        }
    }
}
