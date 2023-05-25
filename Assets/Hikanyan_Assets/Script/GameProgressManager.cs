using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
public class GameProgressManager : AbstractSingleton<GameProgressManager>
{
    public ReactiveProperty<GameState> _gameState = new ReactiveProperty<GameState>();
    [SerializeField] AudioClip _audioClipTitle;
    [SerializeField] AudioClip _audioClipInGame;
    [SerializeField] AudioClip _audioClipResult;
    [SerializeField] float _startTimer = 100f;
    private void Start()
    {
        _gameState.Subscribe(OnGameStateChange);
        _gameState.Value = GameState.None;
    }
    public void OnGameStateChange(GameState state)
    {
        Debug.Log(state);
        switch (state)
        {
            case GameState.Title:
                // タイトル画面の処理
                AudioManager.Instance.PlayMusic(_audioClipTitle);
                break;
            case GameState.GameStart:
                // ゲーム開始の処理
                GameManager.Instance.StartTimer(_startTimer);
                GameManager.Instance.ResetScore();
                AudioManager.Instance.PlayMusic(_audioClipInGame);
                
                break;
            case GameState.GameClear:
                // ゲームクリアの処理
                GameManager.Instance.StopTimer();
                //クリア演出
                break;
            case GameState.GameOver:
                // ゲームオーバーの処理
                GameManager.Instance.StopTimer();
                //ガメオベラ
                break;
            case GameState.Result:
                // 結果表示の処理
                AudioManager.Instance.PlayMusic(_audioClipResult);

                //シーンチェンジ
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
}
