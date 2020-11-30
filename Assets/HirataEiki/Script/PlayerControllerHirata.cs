using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerHirata : MonoBehaviour
{
    Rigidbody2D m_rb2d;
    [SerializeField] float m_speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        m_rb2d.velocity = h * Vector2.right * m_speed;
    }
}
