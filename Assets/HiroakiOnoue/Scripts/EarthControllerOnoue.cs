using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthControllerOnoue : MonoBehaviour
{
    /// <summary>地球の体力</summary>
    [SerializeField] int m_healthPoint = 100;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void Damage()
    {
        if (m_healthPoint < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
