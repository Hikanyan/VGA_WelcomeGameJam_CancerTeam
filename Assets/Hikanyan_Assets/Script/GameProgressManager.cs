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
                // �^�C�g����ʂ̏���
                AudioManager.Instance.PlayMusic(_audioClipTitle);
                break;
            case GameState.GameStart:
                // �Q�[���J�n�̏���
                GameManager.Instance.StartTimer(_startTimer);
                GameManager.Instance.ResetScore();
                AudioManager.Instance.PlayMusic(_audioClipInGame);
                
                break;
            case GameState.GameClear:
                // �Q�[���N���A�̏���
                GameManager.Instance.StopTimer();
                //�N���A���o
                break;
            case GameState.GameOver:
                // �Q�[���I�[�o�[�̏���
                GameManager.Instance.StopTimer();
                //�K���I�x��
                break;
            case GameState.Result:
                // ���ʕ\���̏���
                AudioManager.Instance.PlayMusic(_audioClipResult);

                //�V�[���`�F���W
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
}
