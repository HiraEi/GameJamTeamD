using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation1 : MonoBehaviour
{
    public GameObject[] StarPrefabs; //星のプレハブを管理する配列
    int starIndex = 0;    

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flg();
            starIndex++;
        }
        
    }

    public void Flg()
    {
        // 出現する星のプレハブを配列から取得する
        StarPrefabs[starIndex].SetActive(false);
    }
}
