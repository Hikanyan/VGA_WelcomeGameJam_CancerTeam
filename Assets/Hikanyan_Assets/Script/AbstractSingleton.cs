using System;
using UnityEngine;


public abstract class AbstractSingleton<T> : MonoBehaviour where T : Component
{
    /// <summary>
    /// static Singleton instance
    /// </summary>
    static T _Instance;

    public static T Instance
    {
        get
        {
            if (_Instance == null)
            {
                Type t = typeof(T);
                _Instance = (T)FindObjectOfType(t);
                if (_Instance != null)
                {
                    Debug.LogError($"{t}���A�^�b�`���Ă���GameObject������܂���B");
                    GameObject obj = new GameObject();
                    obj.name = t.Name;
                    _Instance = obj.AddComponent<T>();
                    Debug.LogError($"{t}���A�^�b�`���Ă���GameObject {obj.name} ���쐬���܂����B");
                }
            }
            return _Instance;
        }
    }
    protected virtual void Awake()
    {
        ChackIn();
        OnAwake();
    }
    protected void ChackIn()
    {
        if (_Instance == null)
        {
            _Instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// �p�����Awake���K�v�ȏꍇ
    /// </summary>
    protected virtual void OnAwake() { }
}
