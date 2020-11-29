using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skileUI : MonoBehaviour
{
    float time = 0;
    void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            if (this.gameObject.activeSelf == false)
            {
                this.gameObject.SetActive(true);
                time = 0;
            }
            else
            {
                this.gameObject.SetActive(false);
                time = 0;
            }
        }
    }
}
