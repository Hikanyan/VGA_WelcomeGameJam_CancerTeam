using UnityEngine;

public class JumpUp : MonoBehaviour
{
    // �W�����v����́i������̗́j���`
    [SerializeField] private float jumpForce = 500.0f;

    /// <summary>
    /// Collider�����̃g���K�[�ɓ��������ɌĂяo�����
    /// </summary>
    /// <param name="other">������������̃I�u�W�F�N�g</param>
    //private void OnColliderEnter2D(Collision2D other, Vector2 vector2)
    //{
    //    // ������������̃^�O��Player�������ꍇ
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        // �������������Rigidbody�R���|�[�l���g���擾���āA������̗͂�������
    //        other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ������������̃^�O��Player�������ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jump�䂪�Ă΂ꂽ");
            // �������������Rigidbody�R���|�[�l���g���擾���āA������̗͂�������
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }
    }
}