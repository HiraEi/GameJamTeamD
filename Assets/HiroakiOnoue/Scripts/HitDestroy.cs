using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDestroy : MonoBehaviour
{
    public string meteorite_tag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == meteorite_tag)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
