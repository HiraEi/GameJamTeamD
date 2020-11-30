using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour
{
    [SerializeField] public int m_hp = 10;
    [SerializeField] int m_maxHp = 10;
    [SerializeField] int m_damage = 2;

    private void Start()
    {
        m_hp = m_maxHp;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meteo")
        {
            m_hp -= m_damage;
            Debug.Log($"HIT!{m_damage}のダメージ。のこり{m_hp}");
            if (m_hp < 1)
            {
                m_hp = 0;
                Debug.Log("もう減らない");
            }
        }
    }
}
