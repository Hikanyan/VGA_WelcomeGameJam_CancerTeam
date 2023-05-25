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
       
        if (_audio != null)  // �R���|�[�l���g����ꂽ��
        {
            AudioManager.Instance.PlaySoundEffect(_audio);  // AudioSource �R���|�[�l���g�� AudioClip �v���p�e�B�ɃA�T�C������Ă��鉹��炷
        }
    }

    /// <summary>
    /// �{�[�����g���K�[�ɐڐG�������ɌĂ΂��֐�
    /// </summary>
    /// <param name="collision">�ڐG���</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // OnCollisionEnter2D �Ɠ����̏���������
        
        if (_audio != null)
        {
            AudioManager.Instance.PlaySoundEffect(_audio);
        }
    }

}