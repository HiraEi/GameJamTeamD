using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpGaugeController : MonoBehaviour
{
    private int m_earthHp = 100;
    private int m_meteoDamage = 10;
    private int m_starDamage = 20;
    private Slider m_slider;
    public GameObject image;
    void Start()
    {
        m_slider = this.GetComponent<Slider>();
    }

    void Update()
    {
        m_slider.value = m_earthHp;
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Meteo")
        {
            m_earthHp -= m_meteoDamage;
            Debug.Log("EarthHP" + m_earthHp);
        }
        else if (collision.tag == "Star")
        {
            m_earthHp -= m_starDamage;
            Debug.Log("EarthHP" + m_earthHp);
        }
    }
}
