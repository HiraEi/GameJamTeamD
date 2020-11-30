using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_playerPower = 5f;
    [SerializeField] float m_moveSpeed = 5f;

    [SerializeField] float m_breakInterval = 1f;

    [SerializeField] GameObject m_meteoBreak = default;
    [SerializeField] GameObject m_starBreak = default;

    Rigidbody2D playerRb;
    Vector2 vel;

    Animator m_anim;

    State state;
    bool m_isAttaking = false;
    bool m_magicStandby = false;

    float h;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        state = State.Idol;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        PlayerControl();

        Status();
    }

    void PlayerControl()
    {
        if (h > 0)
        {
            vel = playerRb.velocity;
            vel.x = h * m_moveSpeed;
            playerRb.velocity = vel;
            this.transform.localScale = new Vector2(h, 1);
            state = State.Run;
        }
        else if (h < 0)
        {
            vel = playerRb.velocity;
            vel.x = h * m_moveSpeed;
            playerRb.velocity = vel;
            this.transform.localScale = new Vector2(h, 1);
            state = State.Run;
        }
        else
        {
            vel = playerRb.velocity;
            vel.x = 0;
            playerRb.velocity = vel;
            state = State.Idol;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            m_isAttaking = true;
            state = State.SwordAttack;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            m_isAttaking = true;
            m_magicStandby = true;
            state = State.MagicAttackStandBy;
        }

        if (Input.GetButton("Fire2"))
        {
            m_isAttaking = true;
            if (m_magicStandby) return;
            state = State.MagicAttackStandBy2;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            m_isAttaking = true;
            state = State.MagicAttack;
        }
    }

    void Status()
    {
        switch (state)
        {
            case State.Idol:
                if (m_isAttaking) return; //攻撃中はアニメーションを再生しない
                m_anim.Play("Idol");
                break;
            case State.Run:
                if (m_isAttaking) return; //攻撃中はアニメーションを再生しない
                m_anim.Play("Run");
                break;
            case State.SwordAttack:
                m_anim.Play("SwordAttack");
                break;
            case State.MagicAttackStandBy:
                m_anim.Play("MagicAttackStandBy");
                break;
            case State.MagicAttackStandBy2:
                m_anim.Play("MagicAttackStandBy2");
                break;
            case State.MagicAttack:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// アニメーションイベントから呼ばれる
    /// </summary>
    void FinishAttack()
    {
        m_isAttaking = false;
    }

    /// <summary>
    /// アニメーションイベントから呼ばれる
    /// </summary>
    void FinishStandBy()
    {
        m_magicStandby = false;
    }

    enum State
    {
        Idol, Run, SwordAttack, MagicAttackStandBy, MagicAttackStandBy2, MagicAttack
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meteo")
        {
            if (Input.GetButton("Fire1"))
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.simulated = false;
                yield return new WaitForSeconds(m_breakInterval);
                collision.gameObject.SetActive(false);
                Instantiate(m_meteoBreak, collision.transform.position, collision.transform.rotation);
                rb.simulated = true;
            }
        }
        else if (collision.tag == "Star")
        {
            if (Input.GetButton("Fire1"))
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.simulated = false;
                yield return new WaitForSeconds(m_breakInterval);
                collision.gameObject.SetActive(false);
                Instantiate(m_starBreak, collision.transform.position, collision.transform.rotation);
                rb.simulated = true;
            }
            else if (Input.GetButton("Fire2"))
            {
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                Vector2 vel = rb.velocity;
                vel.y = 0f;
                rb.velocity = vel;
                rb.AddForce(Vector2.up * m_playerPower, ForceMode2D.Impulse);
            }
        }
    }

    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Meteo")
        {
            if (Input.GetButton("Fire1"))
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.simulated = false;
                yield return new WaitForSeconds(m_breakInterval);
                collision.gameObject.SetActive(false);
                Instantiate(m_meteoBreak, collision.transform.position, collision.transform.rotation);
                rb.simulated = true;
            }
        }
        else if (collision.tag == "Star")
        {
            if (Input.GetButton("Fire1"))
            {
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.simulated = false;
                yield return new WaitForSeconds(m_breakInterval);
                collision.gameObject.SetActive(false);
                Instantiate(m_starBreak, collision.transform.position, collision.transform.rotation);
                rb.simulated = true;
            }
            else if (Input.GetButton("Fire2"))
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
