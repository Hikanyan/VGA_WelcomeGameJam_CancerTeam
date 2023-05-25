using UnityEngine;

public class JumpUp : MonoBehaviour
{
    // ジャンプする力（上向きの力）を定義
    [SerializeField] private float jumpForce = 500.0f;

    /// <summary>
    /// Colliderが他のトリガーに入った時に呼び出される
    /// </summary>
    /// <param name="other">当たった相手のオブジェクト</param>
    //private void OnColliderEnter2D(Collision2D other, Vector2 vector2)
    //{
    //    // 当たった相手のタグがPlayerだった場合
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        // 当たった相手のRigidbodyコンポーネントを取得して、上向きの力を加える
    //        other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 当たった相手のタグがPlayerだった場合
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jump台が呼ばれた");
            // 当たった相手のRigidbodyコンポーネントを取得して、上向きの力を加える
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        }
    }
}