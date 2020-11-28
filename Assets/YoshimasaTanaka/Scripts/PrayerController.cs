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
    [SerializeField] AudioClip m_pushSoundNormal = null;
    //飛ばす方向をランダムにする
    [SerializeField] float m_maxForRandom = 3f;//右ブレ
    [SerializeField] float m_minForRandom = -3f;//左ブレ
    //プレイヤーのスキルの数
    [SerializeField]int m_playerSkillCount = 2;

    PlayerSkillCounter m_psc;
    AudioSource m_as;
    GameObject m_tempObj;
    Collider2D[] m_colliders;
    bool m_isSomeThing;
    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_as = GetComponent<AudioSource>();
        m_psc = PlayerSkillCounter.FindObjectOfType<PlayerSkillCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        m_rb.velocity = h * Vector2.right * m_speed;
        Debug.Log(m_playerSkillCount);

        if (Input.GetButtonDown("Fire1"))
        {
            CheckForward();
            Push();
        }

        if (Input.GetButtonDown("Jump"))
        {
           
            m_playerSkillCount++;
            m_psc.Refresh(m_playerSkillCount);
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
        Vector2 forceDir = new Vector2(Random.Range(m_minForRandom, m_maxForRandom), 1f * m_pushPower);

        if (m_colliders != null)
        {
            foreach (var item in m_colliders)
            {
                Rigidbody2D rb2d = item.GetComponent<Rigidbody2D>();
                rb2d.AddForce(forceDir, ForceMode2D.Impulse);
                //FilterTarget(item.gameObject, "Comet");
                if (m_pushSoundNormal != null)
                {
                    m_as.PlayOneShot(m_pushSoundNormal);
                }
            }
        }
    }

    GameObject FilterTarget(GameObject originalObj, string tagName)
    {
        float tmpDis = 0;//一時保存　距離
        float nearestDis = 0;//最も近いオブジェクトの距離

        GameObject targetObj = null;//オブジェクト

        foreach (var item in GameObject.FindGameObjectsWithTag(tagName))
        {
            tmpDis = Vector2.Distance(item.transform.position, originalObj.transform.position);

            if (nearestDis == 0 || nearestDis > tmpDis)
            {
                nearestDis = tmpDis;
                targetObj = item;
            }
        }
        return targetObj;
    }

    void FilterTarget(GameObject originalObj, string tagName, AudioClip pushSound)
    {
        float tmpDis = 0;//一時保存　距離
        float nearestDis = 0;//最も近いオブジェクトの距離

        GameObject targetObj = null;//オブジェクト

        foreach (var item in GameObject.FindGameObjectsWithTag(tagName))
        {
            tmpDis = Vector2.Distance(item.transform.position, originalObj.transform.position);
            if (nearestDis == 0 || nearestDis > tmpDis)
            {
                nearestDis = tmpDis;
                targetObj = item;
            }
        }

    }
}
