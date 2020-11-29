using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earth : MonoBehaviour
{
    [SerializeField] int m_earthHp = 50;
    [SerializeField] int m_cometDamage = 10;

    //githubtest
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Comet")
        {
            m_earthHp -= m_cometDamage;
        }
    }

}
