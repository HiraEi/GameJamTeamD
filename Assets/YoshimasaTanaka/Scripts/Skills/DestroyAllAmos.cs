using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAllAmos : MonoBehaviour
{
    PrayerController m_pc;
    [SerializeField] float m_doubleRange = 2f;//攻撃判定にこの数を掛けて拡大する


    public void DoubleRange()
    {
        Debug.Log("called");
        float m_temp;//もとのradiusを一時保存する
        m_pc = FindObjectOfType<PrayerController>();
        m_temp = m_pc.m_radius;
        m_pc.m_radius *= m_doubleRange;

        m_pc.CheckForward();
        m_pc.BreakTarget();

        m_pc.m_radius = m_temp;
    }

}
