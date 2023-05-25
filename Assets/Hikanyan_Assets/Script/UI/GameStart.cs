using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField] Button testBtn;

    private void Start()
    {
        testBtn.onClick.AddListener(StartGame);
    }
    void StartGame()
    {
        GameManager.Instance._gameState = GameState.GameStart;
    }
}
