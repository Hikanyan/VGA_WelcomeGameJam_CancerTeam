using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChanger : AbstractSingleton<SceneChanger>
{
    [SerializeField, Tooltip("フェード用のパネル")] GameObject _fadePanel;
    [SerializeField, Tooltip("フェードの速度")] float _fadeDuration = 0f;

    private void Start()
    {
        var panelImage = _fadePanel.GetComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 1.0f);
        _fadePanel.SetActive(true);
        panelImage.DOFade(0f, _fadeDuration).OnComplete(() => _fadePanel.SetActive(false));
    }

    /// <summary> フェードアウトしてからシーン遷移するためのメソッド  </summary>
    /// <param name="sceneName">Title, Game, Resultの3つからstringで指定する</param>
    public void LoadAndFadeOut(string sceneName)
    {
        var state = GameState.None;
        switch(sceneName)
        {
            case "Boot":state = GameState.None; break;
            case "TitleScene": state = GameState.Title; break;
            case "GameScene": state = GameState.GameStart; break;
            case "ResultScene": state = GameState.Result;break;
        }
        var panelImage = _fadePanel.GetComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0);
        _fadePanel.SetActive(true);
        panelImage.DOFade(1.0f, _fadeDuration).OnComplete(() => GameManager.Instance._gameState = state)
            .OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
