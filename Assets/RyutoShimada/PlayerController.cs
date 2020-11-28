using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_playerPower = 5f;
    [SerializeField] float m_moveSpeed = 5f;

    Rigidbody2D playerRb;
    Vector2 vel;

    float h;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            vel = playerRb.velocity;
            vel.x = h * m_moveSpeed;
            playerRb.velocity = vel;
        }
        else if (h < 0)
        {
            vel = playerRb.velocity;
            vel.x = h * m_moveSpeed;
            playerRb.velocity = vel;
        }
        else
        {
            vel = playerRb.velocity;
            vel.x = 0;
            playerRb.velocity = vel;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meteo")
        {
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Star")
        {
            if (Input.GetButton("Fire1"))
            {
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                Vector2 vel = rb.velocity;
                vel.y = 0f;
                rb.velocity = vel;
                rb.AddForce(Vector2.up * m_playerPower, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Meteo")
        {
            if (Input.GetButton("Fire1"))
            {
                Destroy(collision.gameObject);
            }
        }
        else if (collision.tag == "Star")
        {
            if (Input.GetButton("Fire1"))
            {
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                Vector2 vel = rb.velocity;
                vel.y = 0f;
                rb.velocity = vel;
                rb.AddForce(Vector2.up * m_playerPower, ForceMode2D.Impulse);
            }
        }
    }
}
