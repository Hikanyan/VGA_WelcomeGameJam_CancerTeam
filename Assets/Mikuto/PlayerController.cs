using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] int m_maxHp = 100;
    int m_hp;
    [SerializeField] float m_speed = 1f;
    [SerializeField] float m_maxSpeed = 10f;
    [SerializeField] float m_jumpPower = 1f;
    [SerializeField] AudioClip m_audioClip = default;
    CapsuleCollider2D m_capsuleCollider2D = default;
    CircleCollider2D m_circleCollider2D = default;
    BoxCollider2D m_boxCollider2D = default;
    Rigidbody2D m_rb = default;
    Animator m_animator;
    SpriteRenderer m_spriteRenderer;
    float m_horizontal;
    bool isGrounded = false;
    bool isJumping = false;

    public int Hp
    {
        get { return m_hp; }
        set
        {
            m_hp = Mathf.Clamp(value, 0, m_maxHp);

            if (m_hp <= 0)
            {
                Death();
            }
        }
    }
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        m_circleCollider2D = GetComponent<CircleCollider2D>();
        m_boxCollider2D = GetComponent<BoxCollider2D>();
        
        Hp = m_maxHp;
    }
    public void Damage(int value)
    {
        Hp -= value;
    }
    public void Death()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        m_horizontal = Input.GetAxisRaw("Horizontal");
        float speedX = Mathf.Abs(this.m_rb.velocity.x);

        if(Input.GetButtonDown("Fire1"))//çUåÇéËíi
        {
            m_animator.SetBool("attack", true);
        }
        else
        {
            m_animator.SetBool("attack", false);
        }

        if(m_horizontal != 0)//â°à⁄ìÆ
        {
            m_animator.SetBool("run", true);
            if(m_horizontal < 0)
            {
                m_boxCollider2D.offset = new Vector2(-0.05f, 0);
                m_circleCollider2D.offset = new Vector2(0.1f, -0.21f);
                m_capsuleCollider2D.offset = new Vector2(0.1f, 0);
                m_spriteRenderer.flipX = true;
            }
            else
            {
                m_boxCollider2D.offset = new Vector2(0.05f, 0);
                m_circleCollider2D.offset = new Vector2(-0.1f, -0.21f);
                m_capsuleCollider2D.offset = new Vector2(-0.1f, 0);
                m_spriteRenderer.flipX = false;
            }
            if (speedX <= m_maxSpeed)
            {
                m_rb.AddForce(Vector2.right * m_horizontal * m_speed, ForceMode2D.Force);
            }
        }
        else
        {
            m_animator.SetBool("run", false);
        }

        if (Input.GetButtonDown("Jump") && (isGrounded || isJumping))//ÉWÉÉÉìÉvèàóù
        {
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            AudioManager.Instance.PlaySoundEffect(m_audioClip);
            if (isJumping)
            {
                isJumping = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        m_animator.SetBool("jump", false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        isJumping = true;
        m_animator.SetBool("jump", true);
    }
}

public interface IDamageable
{
    public void Damage(int value);
    public void Death();
}