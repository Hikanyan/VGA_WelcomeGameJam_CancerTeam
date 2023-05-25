using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_speed = 1f;
    [SerializeField] float m_jumpPower = 1f;
    [SerializeField] AudioSource m_audioSource = default;
    Rigidbody2D m_rb = default;
    float m_horizontal;
    bool isGrounded = false;
    bool isJumping = false;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
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
