using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] Text _text = default;
    [SerializeField] GameObject _gameObject = default;
    int _hp;

    void Update()
    {
        _hp = _gameObject.GetComponent<PlayerController>().m_hp;
        _text.text = $"HP:{_hp}";
    }
}
