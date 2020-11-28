using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthController : MonoBehaviour
{
    [SerializeField] int m_earthHp = 100;
    [SerializeField] int m_meteoDamage = 10;
    [SerializeField] int m_starDamage = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
