using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    [SerializeField, Tooltip("�t�F�[�h�p�̃p�l��")] GameObject _fadePanel;
    [SerializeField, Tooltip("�t�F�[�h�̑��x")] float _fadeDuration = 0f;

    private void Start()
    {
        var panelImage = _fadePanel.GetComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 1.0f);
        _fadePanel.SetActive(true);
        panelImage.DOFade(0f, _fadeDuration).OnComplete(() => _fadePanel.SetActive(false));
    }

    /// <summary> �t�F�[�h�A�E�g���Ă���V�[���J�ڂ��邽�߂̃��\�b�h  </summary>
    /// <param name="sceneName"></param>
    public void LoadAndFadeOut(string sceneName)
    {
        var panelImage = _fadePanel.GetComponent<Image>();
        panelImage.color = new Color(0, 0, 0, 0);
        _fadePanel.SetActive(true);
        panelImage.DOFade(1.0f, _fadeDuration).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}
