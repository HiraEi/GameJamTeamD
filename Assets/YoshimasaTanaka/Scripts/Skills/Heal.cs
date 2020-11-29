using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    EarthManager m_em;
    public void HealEathLife(int healPoint)
    {
        Debug.Log("回復する");
        m_em = GetComponent<EarthManager>();
        m_em.m_hp += healPoint;
    }
}
