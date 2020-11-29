using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    [SerializeField] float m_pushPower = 10f;
    
    CometController[] m_cc;


    public void SlowAmmo()
    {
        Debug.Log("called");
        m_cc = FindObjectsOfType<CometController>();
        foreach (var item in m_cc)
        {
            Rigidbody2D rb = item.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * m_pushPower, ForceMode2D.Impulse);
        }
    }


}
