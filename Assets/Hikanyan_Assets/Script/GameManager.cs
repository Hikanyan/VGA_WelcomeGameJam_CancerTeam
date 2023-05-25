using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class GameManager : AbstractSingleton<GameManager>
{
    public GameState _gameState = GameState.None;

    private ScoreManager scoreManager;
    private TimerManager timerManager;

    private void Start()
    {
        scoreManager = new ScoreManager();
        timerManager = new TimerManager();
        _gameState  = GameState.None;
    }

    public void AddScore(int points)
    {
        scoreManager.AddScore(points);
    }

    public void ResetScore()
    {
        scoreManager.ResetScore();
    }

    public async UniTask StartTimer(float duration)
    {
        await timerManager.StartTimer(duration);
    }
    public void StopTimer()
    {
        timerManager.StopTimer();
    }

    public void ResetTimer()
    {
        timerManager.ResetTimer();
    }
}
