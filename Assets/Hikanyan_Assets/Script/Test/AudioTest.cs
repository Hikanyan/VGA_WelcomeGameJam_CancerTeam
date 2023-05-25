using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip a;
    void Start()
    {
        AudioManager.Instance.PlaySoundEffect(a);
    }
}
