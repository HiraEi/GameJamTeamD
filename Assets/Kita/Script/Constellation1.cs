using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constellation1 : MonoBehaviour
{
    public GameObject[] StarPrefabs; //星のプレハブを管理する配列
    int starIndex = 0;

    [SerializeField] GameObject loadSceneManagerObject = default;
    LoadSceneManagerM loadSceneManager;

    void Start()
    {
        loadSceneManager = loadSceneManagerObject.GetComponent<LoadSceneManagerM>();
    }

    // Update is called once per frame
    void Update()
    {
        if (starIndex == StarPrefabs.Length)
        {
            loadSceneManager.LoadResultScene();
        }
    }

    public void Flg()
    {
        // 出現する星のプレハブを配列から取得する
        StarPrefabs[starIndex].SetActive(false);
        //Debug.Log("index:" + starIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Star")
        {
            Flg();
            starIndex++;
        }
    }
}
