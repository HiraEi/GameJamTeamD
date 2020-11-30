using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometController : MonoBehaviour
{
    /// <summary>爆発エフェクトのプレハブ</summary>
    [SerializeField] GameObject m_explosionPrefab = null;

    [SerializeField] float m_lifeTime = 0.2f;
    public bool m_isDead = false;
    float m_timer;

    //りゅうとのやつ
    /// <summary>落下速度</summary>
    [SerializeField] public float m_speed = 5f;
    public float m_maxSpeed = 0f;
    /// <summary>落下速度をランダムにするかどうか</summary>
    [SerializeField] bool m_randomSpeed = false;
    /// <summary>ランダムの最低値</summary>
    [SerializeField] float m_rangeMin = 1f;
    /// <summary>ランダムの最高値</summary>
    [SerializeField] float m_rangeMax = 3f;

    Rigidbody2D m_rb;
    bool m_flag = false;

    void Start()
    {
        m_maxSpeed = m_speed;
        m_rb = this.gameObject.GetComponent<Rigidbody2D>();
    }


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

    //りゅうとのやつ終わり

    public IEnumerator BreakThis()
    {
        Debug.Log($"呼ばれた{m_isDead}");
        if (m_isDead)
        {
            StartCoroutine("Destruction");
            yield return new WaitForSeconds(0.2f);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject, 0.2f);

        }
    }

    public IEnumerator Destruction()
    {
        Debug.Log("Called");
        if (m_isDead)
        {
            yield return new WaitForSeconds(0.18f);
            Instantiate(m_explosionPrefab, this.transform.position, m_explosionPrefab.transform.rotation);
        }
    }
}
