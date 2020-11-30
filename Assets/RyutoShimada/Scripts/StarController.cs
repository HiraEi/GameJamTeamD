using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    /// <summary>落下速度</summary>
    [SerializeField] float m_speed = 5f;

    /// <summary>落下速度をランダムにするかどうか</summary>
    [SerializeField] bool m_randomSpeed = false;
    /// <summary>ランダムの最低値</summary>
    [SerializeField] float m_rangeMin = 1f;
    /// <summary>ランダムの最高値</summary>
    [SerializeField] float m_rangeMax = 3f;

    Rigidbody2D m_rb;

    [SerializeField] GameObject m_starBreak = default;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_randomSpeed) //ランダムON
        {
            m_rb.AddForce(Vector2.down * Random.Range(m_rangeMin, m_rangeMax), ForceMode2D.Force);
        }
        else
        {
            m_rb.AddForce(Vector2.down * m_speed, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit");

        if (collision.tag == "TheEarth")
        {
            this.gameObject.SetActive(false);
            Instantiate(m_starBreak, this.transform.position, this.transform.rotation);
        }

        //星を打ち返した時に設置判定に触れたら
        if (collision.tag == "aaa")
        {
            this.gameObject.SetActive(false);
        }
    }
}
