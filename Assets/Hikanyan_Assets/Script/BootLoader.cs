using UnityEngine;

public class BootLoader : MonoBehaviour
{
    [SerializeField]
    SequenceManager sequenceManagerPrefab;

    void Start()
    {
        Instantiate(sequenceManagerPrefab);
        SequenceManager.Instance.Initialize();
    }
}
