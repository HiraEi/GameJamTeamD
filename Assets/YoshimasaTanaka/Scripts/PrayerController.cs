using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayerController : MonoBehaviour
{
    [SerializeField] float m_speed = 5f;
    [SerializeField] public float m_radius = 5f;//オーバーラップの半径
    [SerializeField] float m_length = 5f;//オーバーラップを出す位置
    [SerializeField] GameObject m_atackEffectPrefab = null; //攻撃エフェクトのプレハブ
    [SerializeField] Transform m_muzzle = null; //攻撃を出す場所
    [SerializeField] float m_lifeTime = 0.5f;//この時間経過すると攻撃エフェクトが消える
    [SerializeField] LayerMask m_mask; //レイヤーマスク.
    [SerializeField] float m_pushPower = 5f;
    [SerializeField] AudioClip m_pushSoundNormal = null;
    //飛ばす方向をランダムにする
    [SerializeField] float m_maxForRandom = 3f;//右ブレ
    [SerializeField] float m_minForRandom = -3f;//左ブレ
    //プレイヤーのスキルの数
    [SerializeField] int m_playerSkillCount = 2;
    /// <summary>爆発エフェクトのプレハブ</summary>
    [SerializeField] GameObject m_explosionPrefab = null;
    /// <summary>
    /// スキル
    /// </summary>
    [SerializeField] Skill skill;
    [SerializeField] bool m_canUseSkill = true;
    bool m_finishCoolTimeH = true;
    [SerializeField] GameObject m_heal;
    [SerializeField] float m_healCool = 5f;
    float m_timerH = 0f;
    bool m_finishCoolTimeD = true;
    [SerializeField] GameObject m_destroy;
    [SerializeField] float m_destroyCool = 5f;
    float m_timerD = 0f;
    bool m_finishCoolTimeS = true;
    [SerializeField] GameObject m_slow;
    [SerializeField] float m_slowCool = 5f;
    float m_timerS = 0f;


    PlayerSkillCounter m_psc;
    AudioSource m_as;
    GameObject m_tempObj;
    Collider2D[] m_colliders;
    EarthManager m_em;
    bool m_isSomeThing;
    Rigidbody2D m_rb;
    Animator m_anim;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_as = GetComponent<AudioSource>();
        m_anim = GetComponent<Animator>();
        m_psc = PlayerSkillCounter.FindObjectOfType<PlayerSkillCounter>();
        m_finishCoolTimeH = true;

        //クールタイムを初期化
        m_timerH = 0;
        m_timerD = 0;
        m_timerS = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        m_rb.velocity = h * Vector2.right * m_speed;


        //移動するときにアニメーションをする

        if (m_rb.velocity.x > 1)/*右に移動している*/
        {
            this.transform.localScale = new Vector2(1, 1);
            m_anim.Play("Run");
        }
        else if (m_rb.velocity.x < -1)
        {
            this.transform.localScale = new Vector2(-1, 1);
            m_anim.Play("Run");
        }

        //左クリックで弾き返す 隕石も★も破壊
        if (Input.GetButtonDown("Fire1"))
        {
            CheckForward();
            m_anim.Play("WeaponAnim");
            BreakTarget();
        }

        //右クリックで星を飛ばす
        if (Input.GetButtonDown("Fire2"))
        {
            CheckForward();
            m_anim.Play("MagicAnim");
            Push();
        }

        //仮のスキル
        if (m_canUseSkill)
        {
            switch (skill)
            {
                case Skill.Stage1:
                    break;
                case Skill.Stage2:
                    HealEarth();
                    break;
                case Skill.Stage3:
                    HealEarth();
                    DestroyAllAmmo();
                    break;
                case Skill.Stage4:
                    HealEarth();
                    DestroyAllAmmo();
                    SlowAmmo();
                    break;
                default:
                    break;
            }
        }

    }

    void HealEarth()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && m_finishCoolTimeH)
        {
            Heal heal = Heal.FindObjectOfType<Heal>();
            heal.HealEathLife();
            m_finishCoolTimeH = false;
        }

        if (!m_finishCoolTimeH)
        {
            Debug.Log(m_finishCoolTimeH);
            m_timerH += Time.deltaTime;
            if (m_timerH >= m_healCool)
            {
                m_finishCoolTimeH = true;
                m_timerH = 0;
            }
        }
    }



    void DestroyAllAmmo()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && m_finishCoolTimeD)
        {
            DestroyAllAmos destroy = DestroyAllAmos.FindObjectOfType<DestroyAllAmos>();
            destroy.DoubleRange();
            m_finishCoolTimeD = false;
        }
        if (!m_finishCoolTimeD)
        {
            Debug.Log(m_finishCoolTimeD);
            m_timerD += Time.deltaTime;
            if (m_timerD >= m_healCool)
            {
                m_finishCoolTimeD = true;
                m_timerD = 0;
            }
        }
    }

    void SlowAmmo()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && m_finishCoolTimeS)
        {
            Slow slow = Slow.FindObjectOfType<Slow>();
            slow.SlowAmmo();
            m_finishCoolTimeS = false;
        }
        else if (!m_finishCoolTimeS)
        {
            Debug.Log(m_finishCoolTimeS);
            m_timerS += Time.deltaTime;
            if (m_timerS >= m_healCool)
            {
                m_finishCoolTimeS = true;
                m_timerS = 0;
            }
        }
    }

    /// <summary>
    /// 前方をチェックする
    /// </summary>
    public void CheckForward()
    {
        Debug.Log("押した");
        Vector2 point = this.transform.position;
        Vector2 start = point + Vector2.up * m_length;
        m_colliders = Physics2D.OverlapCircleAll(start, m_radius, m_mask);

        GameObject go = Instantiate(m_atackEffectPrefab, m_muzzle.transform.position, m_atackEffectPrefab.transform.rotation, this.gameObject.transform);
        Destroy(go, m_lifeTime);


        Debug.DrawLine(start + Vector2.down * m_radius, start + Vector2.up * m_radius);
        Debug.DrawLine(start + Vector2.right * m_radius, start + Vector2.left * m_radius);
    }

    /// <summary>
    /// CheckForwardの範囲内にあるオブジェクトをtagで識別して上方向に飛ばす。
    /// </summary>
    void Push()
    {
        Vector2 forceDir = new Vector2(Random.Range(m_minForRandom, m_maxForRandom), 1f * m_pushPower);

        if (m_colliders != null)
        {
            foreach (var item in m_colliders)
            {
                //もし★だったら弾き返す
                if (item.tag == "Star")
                {
                    Rigidbody2D rb2d = item.GetComponent<Rigidbody2D>();
                    rb2d.gravityScale = 0;
                    rb2d.AddForce(forceDir, ForceMode2D.Impulse);
                }


                //FilterTarget(item.gameObject, "Comet");
                if (m_pushSoundNormal != null)
                {
                    m_as.PlayOneShot(m_pushSoundNormal);
                }
            }
        }
    }

    /// <summary>
    /// CheckForwardの範囲内にあるオブジェクトをtagで識別して壊す。CometControllerを全ての星につけておく
    /// </summary>
    public void BreakTarget()
    {
        Vector2 forceDir = new Vector2(Random.Range(m_minForRandom, m_maxForRandom), 1f * m_pushPower);
        foreach (var item in m_colliders)
        {
            //もし隕石だったら撃ち返して数秒後に壊す
            if (item.tag == "Meteo" || item.tag == "Star")
            {
                Rigidbody2D rb2d = item.GetComponent<Rigidbody2D>();
                rb2d.AddForce(forceDir, ForceMode2D.Impulse);

                CometController cc = item.gameObject.GetComponent<CometController>();
                cc.m_isDead = true;
                cc.StartCoroutine("BreakThis");
            }
        }

    }

    /// <summary>
    /// originalObjに最も近いオブジェクトを判別する
    /// </summary>
    /// <param name="originalObj">このオブジェクトをもとにして判定する</param>
    /// <param name="tagName">このタグがついたオブジェクトを判定する</param>
    /// <returns></returns>
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

    public void HealEathLife(int healPoint)
    {
        Debug.Log("回復する");
        m_em = GetComponent<EarthManager>();
        m_em.m_hp += healPoint;
    }

    enum Skill
    {
        Stage1, Stage2, Stage3, Stage4,
    }
}
