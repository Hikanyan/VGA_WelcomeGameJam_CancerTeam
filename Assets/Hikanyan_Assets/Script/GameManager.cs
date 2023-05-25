using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
public enum GameState
    {
        Title,
        GameStart,
        GameEnd,
        Result,
        Explanation,
        None
    }
public class GameManager : AbstractSingleton<GameManager>
{
    

    private ScoreManager scoreManager;
    private TimerManager timerManager;

    private void Start()
    {
        scoreManager = new ScoreManager();
        timerManager = new TimerManager();
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

    public void ResetTimer()
    {
        timerManager.ResetTimer();
    }
}
