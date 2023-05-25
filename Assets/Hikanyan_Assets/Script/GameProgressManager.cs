using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameProgressManager : AbstractSingleton<GameProgressManager>
{
    private readonly ReactiveProperty<GameState> _gameState = new ReactiveProperty<GameState>();
    [SerializeField] AudioClip _audioClipTitle;
    [SerializeField] AudioClip _audioClipInGame;
    [SerializeField] AudioClip _audioClipResult;
    private void Start()
    {
        _gameState.Subscribe(OnGameStateChange);
    }
    public void OnGameStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.Title:
                // タイトル画面の処理
                AudioManager.Instance.PlayMusic(_audioClipTitle);

                break;
            case GameState.GameStart:
                // ゲーム開始の処理
                AudioManager.Instance.PlayMusic(_audioClipInGame);
                break;
            case GameState.GameEnd:
                // ゲーム終了の処理
                break;
            case GameState.Result:
                // 結果表示の処理
                AudioManager.Instance.PlayMusic(_audioClipResult);
                break;
            case GameState.Explanation:
                // ゲーム説明の処理
                break;
            case GameState.None:
                // 未定義の状態の処理
                break;
            default:
                // その他の状態の処理
                break;
        }
    }
    public void ChangeGameState(GameState state)
    {
        _gameState.Value = state;
    }
    public void StartGame(float gameDuration)
    {
        GameManager.Instance.ResetScore();
        GameManager.Instance.StartTimer(gameDuration);
    }
}
