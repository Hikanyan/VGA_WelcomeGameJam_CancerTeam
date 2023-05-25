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
                // �^�C�g����ʂ̏���
                AudioManager.Instance.PlayMusic(_audioClipTitle);

                break;
            case GameState.GameStart:
                // �Q�[���J�n�̏���
                AudioManager.Instance.PlayMusic(_audioClipInGame);
                break;
            case GameState.GameEnd:
                // �Q�[���I���̏���
                break;
            case GameState.Result:
                // ���ʕ\���̏���
                AudioManager.Instance.PlayMusic(_audioClipResult);
                break;
            case GameState.Explanation:
                // �Q�[�������̏���
                break;
            case GameState.None:
                // ����`�̏�Ԃ̏���
                break;
            default:
                // ���̑��̏�Ԃ̏���
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
