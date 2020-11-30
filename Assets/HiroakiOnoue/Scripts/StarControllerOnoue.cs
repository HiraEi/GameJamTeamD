using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarControllerOnoue : MonoBehaviour
{
    /// <summary>星が最初に動く方向</summary>
    [SerializeField] Vector2 m_powerDirection = Vector2.down;
    /// <summary>星の動く力</summary>
    [SerializeField] float m_powerScale = 5f;
    /// <summary>星の最高速度</summary>
    [SerializeField] float m_maxSpeed = 3f;
    Rigidbody2D m_rb2D;
    void Start()
    {
        m_rb2D = GetComponent<Rigidbody2D>();
        Push();
    }
    void Update()
    {
        if (m_rb2D.velocity.magnitude > m_maxSpeed)
        {
            m_rb2D.velocity = m_rb2D.velocity.normalized * m_maxSpeed;
        }
    }
    public void Push()
    {
        m_rb2D.AddForce(m_powerDirection.normalized * m_powerScale, ForceMode2D.Impulse);
    }
}
