using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    EarthManager m_em;
    [SerializeField] int m_healPoint;
    [SerializeField] AudioClip m_healSound = null;
    AudioSource m_as;
    public void HealEathLife()
    {
        m_as = GetComponent<AudioSource>();
        Debug.Log("回復する");
        //音を鳴らす
        if (m_healSound != null)
        {
            m_as.PlayOneShot(m_healSound);
        }
        m_em = FindObjectOfType<EarthManager>();
        m_em.m_hp += m_healPoint;
    }
}
