using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionCheck : MonoBehaviour
{
    /// <summary>
    /// ������ɓG���ǂ�����
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string groundTag = "Ground";
    private string enemyTag = "Enemy";


    #region//�ڐG����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            isOn = false;
        }
    }
    #endregion
}