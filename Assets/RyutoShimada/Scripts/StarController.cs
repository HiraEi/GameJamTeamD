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
    bool m_flag = false;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_flag) return; //フラグが立っているなら返す

        if (m_randomSpeed) //ランダムON
        {
            m_rb.AddForce(Vector2.down * Random.Range(m_rangeMin, m_rangeMax), ForceMode2D.Force);
        }
        else
        {
            m_rb.AddForce(Vector2.down * m_speed, ForceMode2D.Force);
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        //Playerに跳ね返されるとAddforceを止める
        if (collision.tag == "Player")
        {
            m_flag = true;
        }

        if (collision.tag == "TheEarth")
        {
            m_flag = false;
            this.gameObject.SetActive(false);
        }
    }*/
}
