using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] int m_maxHp = 100;
    int m_hp;
    [SerializeField] float m_speed = 1f;
    [SerializeField] float m_jumpPower = 1f;
    [SerializeField] AudioSource m_audioSource = default;
    Rigidbody2D m_rb = default;
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
        m_rb.AddForce(Vector2.right * m_horizontal * m_speed, ForceMode2D.Force);

        if (Input.GetButtonDown("Jump") && (isGrounded || isJumping))
        {
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
            m_audioSource.Play();
            if (isJumping)
            {
                isJumping = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        isJumping = true;
    }
}

public interface IDamageable
{
    public void Damage(int value);
    public void Death();
}