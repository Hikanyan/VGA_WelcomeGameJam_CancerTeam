//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//public class enemy_zako : MonoBehaviour
//{
//    #region//�C���X�y�N�^�[�Őݒ肷��
//    [Header("�ړ����x")] public float speed;
//    [Header("�d��")] public float gravity;
//    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;
//    #endregion

//    #region//�v���C�x�[�g�ϐ�
//    private Rigidbody2D rb = null;
//    private SpriteRenderer sr = null;
//    private Animator anim = null;
//    //private ObjectCollision oc = null;
//    private BoxCollider2D col = null;
//    private bool rightTleftF = false;
//    private bool isDead = false;
//    #endregion

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        sr = GetComponent<SpriteRenderer>();
//        anim = GetComponent<Animator>();
//        //oc = GetComponent<ObjectCollision>();
//        col = GetComponent<BoxCollider2D>();
//    }

//    void FixedUpdate()
//    {
//        if (!oc.playerStepOn)
//        {
//            if (sr.isVisible || nonVisibleAct)
//            {
//                int xVector = -1;
//                if (rightTleftF)
//                {
//                    xVector = 1;
//                    transform.localScale = new Vector3(-1, 1, 1);
//                }
//                else
//                {
//                    transform.localScale = new Vector3(1, 1, 1);
//                }
//                rb.velocity = new Vector2(xVector * speed, -gravity);
//            }
//            else
//            {
//                rb.Sleep();
//            }
//        }
//        else
//        {
//            if (!isDead)
//            {
//                anim.Play("dead");
//                rb.velocity = new Vector2(0, -gravity);
//                isDead = true;
//                col.enabled = false;
//                Destroy(gameObject, 3f);
//            }
//            else
//            {
//                transform.Rotate(new Vector3(0, 0, 5));
//            }
//        }
//    }
//}