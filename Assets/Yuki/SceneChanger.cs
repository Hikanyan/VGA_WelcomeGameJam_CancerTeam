using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
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
    /// <param name="sceneName"></param>
    public void LoadAndFadeOut(string sceneName)
    {
        var panelImage = _fadePanel.GetComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0);
        _fadePanel.SetActive(true);
        panelImage.DOFade(1.0f, _fadeDuration).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
