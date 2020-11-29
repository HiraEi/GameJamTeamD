using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    /// <summary>キャラクターの移動速度</summary>
    [SerializeField] float m_speed = 5f;
    [SerializeField] float m_playerPower; 
    Rigidbody2D m_rb2d;
    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 水平方向の入力を検出する
        float h = Input.GetAxisRaw("Horizontal");
        // 入力に応じてパドルを水平方向に動かす
        m_rb2d.velocity = h * Vector2.right * m_speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Star")
        {
            if (Input.GetButton("Fire1"))
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                Vector2 vel = rb.velocity;
                vel.y = 0f;
                rb.velocity = vel;
                rb.AddForce(Vector2.up * m_playerPower, ForceMode2D.Impulse);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Meteorite")
        {
            Destroy(this.gameObject);
        }
    }
}
