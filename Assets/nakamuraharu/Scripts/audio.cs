using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip _audio;
    private IEnumerator SampleCoroutine()
    {

        yield return new WaitForSeconds(1.0f);
        AudioManager.Instance.PlaySoundEffect(_audio);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (_audio != null)  // コンポーネントが取れたら
        {
            AudioManager.Instance.PlaySoundEffect(_audio);  // AudioSource コンポーネントの AudioClip プロパティにアサインされている音を鳴らす
        }
    }

    /// <summary>
    /// ボールがトリガーに接触した時に呼ばれる関数
    /// </summary>
    /// <param name="collision">接触情報</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // OnCollisionEnter2D と同じの処理をする
        
        if (_audio != null)
        {
            AudioManager.Instance.PlaySoundEffect(_audio);
        }
    }

}