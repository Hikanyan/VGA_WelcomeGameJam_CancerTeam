using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        SceneManager.LoadScene("GameScene");
        GameProgressManager.Instance._gameState.Value = GameState.GameStart;
    }
}
