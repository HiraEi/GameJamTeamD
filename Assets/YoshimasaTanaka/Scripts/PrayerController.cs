using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerController : MonoBehaviour
{
    [SerializeField] float m_speed = 5f;
    [SerializeField] float m_radius = 5f;//オーバーラップの半径
    [SerializeField] float m_length = 5f;//オーバーラップを出す位置
    [SerializeField] LayerMask m_mask;
    [SerializeField] float m_pushPower = 5f;

    GameObject m_tempObj;
    Collider2D[] m_colliders;
    bool m_isSomeThing;
    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        m_rb.velocity = h * Vector2.right * m_speed;

        if (Input.GetButtonDown("Fire1"))
        {
            CheckForward();
            Push();

        }
    }

    /// <summary>
    /// 前方をチェックする
    /// </summary>
    void CheckForward()
    {
        Debug.Log("押した");
        Vector2 point = this.transform.position;
        Vector2 start = point + Vector2.up * m_length;
        m_colliders = Physics2D.OverlapCircleAll(start, m_radius, m_mask);

        Debug.DrawLine(start + Vector2.down * m_radius, start + Vector2.up * m_radius);
        Debug.DrawLine(start + Vector2.right * m_radius, start + Vector2.left * m_radius);

    }

    void Push()
    {
        if (m_colliders != null)
        {
            foreach (var item in m_colliders)
            {
                Rigidbody2D rb2d = item.GetComponent<Rigidbody2D>();
                rb2d.AddForce(Vector2.up * m_pushPower, ForceMode2D.Impulse);
            }
        }
    }
}
