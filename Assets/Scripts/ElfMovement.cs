using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfMovement : MonoBehaviour
{
    private float m_speedCurrent = 5f;
    private float m_speedStandard = 5f;
    private float m_speedIncreased = 8f;
    private Rigidbody2D m_rigidbody;
    private Vector2 m_movement;
    private Animator m_animator;

    void Start()
    {
        m_rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        m_animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Sprint();
    }

    void FixedUpdate()
    {
        SetPosition();
    }

    private void SetPosition()
    {
        m_rigidbody.MovePosition(m_rigidbody.position + m_movement * m_speedCurrent * Time.fixedDeltaTime);
    }
    private void Move()
    {
        m_movement.x = Input.GetAxisRaw("Horizontal");
        m_movement.y = Input.GetAxisRaw("Vertical");

        m_animator.SetFloat("horizontal", m_movement.x);
        m_animator.SetFloat("vertical", m_movement.y);
        m_animator.SetFloat("speed", m_movement.sqrMagnitude);
    }

    private void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_speedCurrent = m_speedIncreased;
        }
        if (Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            m_speedCurrent = m_speedStandard;
        }
    }
}
