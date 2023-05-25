using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneChanger.Instance.LoadAndFadeOut("TitleScene");
        GameProgressManager.Instance._gameState.Value = GameState.Title;
    }
}
