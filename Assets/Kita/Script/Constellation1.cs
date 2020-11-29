using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (SceneManager.GetActiveScene().name == "GameScene" && starIndex == StarPrefabs.Length)
        {
            loadSceneManager.LoadClearScene1();
        }
        else if (SceneManager.GetActiveScene().name == "GameSceneStage2" && starIndex == StarPrefabs.Length)
        {
            loadSceneManager.LoadClearScene2();
        }
        else if (SceneManager.GetActiveScene().name == "GameSceneStage3" && starIndex == StarPrefabs.Length)
        {
            loadSceneManager.LoadClearScene3();
        }
        else if (SceneManager.GetActiveScene().name == "GameSceneStage4" && starIndex == StarPrefabs.Length)
        {
            loadSceneManager.LoadClearScene4();
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
