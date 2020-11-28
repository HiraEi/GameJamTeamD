using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject m_meteo = default;
    [SerializeField] GameObject m_star = default;
    [SerializeField] Transform m_meteoPool = default;
    [SerializeField] Transform m_starPool = default;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Generate(this.gameObject);
    }

    /// <summary>
    /// オブジェクトプールで生成
    /// </summary>
    /// <param name="generater">生成場所</param>
    void Generate(GameObject generater)
    {
        foreach (Transform t in m_meteoPool)
        {
            //オブジェが非アクティブなら使い回し
            if (!t.gameObject.activeSelf)
            {
                t.SetPositionAndRotation(generater.transform.position, generater.transform.rotation);
                t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
            }
        }

        foreach (Transform t in m_starPool)
        {
            //オブジェが非アクティブなら使い回し
            if (!t.gameObject.activeSelf)
            {
                t.SetPositionAndRotation(generater.transform.position, generater.transform.rotation);
                t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
            }
        }
    }
}
