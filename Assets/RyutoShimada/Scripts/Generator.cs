using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    /// <summary>隕石のコルーチンインターバル</summary>
    [SerializeField] float m_meteoColutinInterval = 3;
    /// <summary>隕石生成のインターバル</summary>
    [SerializeField] int m_meteoInterval = 3;
    /// <summary>星生成のインターバル</summary>
    [SerializeField] float m_starInterval = 5;
    /// <summary>隕石の生成数</summary>
    [SerializeField] int m_meteoInstans = 1;
    /// <summary>隕石の生成数</summary>
    [SerializeField] int m_starInstans = 1;
    /// <summary>隕石のオブジェクト</summary>
    [SerializeField] Transform m_meteo = default;
    /// <summary>星のオブジェクト</summary>
    [SerializeField] Transform m_star = default;
    /// <summary>隕石のプール場所</summary>
    [SerializeField] Transform m_meteoPool = default;
    /// <summary>星のプール場所</summary>
    [SerializeField] Transform m_starPool = default;
    /// <summary>generatorの生成範囲（左）</summary>
    [SerializeField] GameObject m_leftEnd = default;
    /// <summary>generatorの生成範囲（右）</summary>
    [SerializeField] GameObject m_rightEnd = default;

    /// <summary>generatorの生成範囲（ランダム指定）</summary>
    Vector2 randomRange;
    /// <summary>ランダムの最低値</summary>
    float rangeMin;
    /// <summary>ランダムの最高値</summary>
    float rangeMax;

    /// <summary>隕石生成までの時間経過</summary>
    float m_meteoTime;
    /// <summary>星生成までの時間経過</summary>
    float m_starTime;

    // Start is called before the first frame update
    void Start()
    {
        //生成ポジションを入れる
        rangeMin = m_leftEnd.transform.position.x;
        rangeMax = m_rightEnd.transform.position.x;

        //すぐに生成される
        m_meteoTime = m_meteoInterval;
        m_starTime = m_starInterval;

        //check
        //if () { }

        //最初に決められた個数を生成
        for (int i = 0; i < m_meteoInstans; i++) //meteo生成
        {
            Instantiate(m_meteo, randomRange, this.transform.rotation, m_meteoPool);
        }
        for (int i = 0; i < m_starInstans; i++) //starの生成
        {
            Instantiate(m_star, randomRange, this.transform.rotation, m_starPool);
        }


    }

    // Update is called once per frame
    void Update()
    {
        //生成までの時間を計測
        m_meteoTime += Time.deltaTime;
        m_starTime += Time.deltaTime;

        //生成位置をランダムにするための処理
        randomRange = new Vector2(Random.Range(rangeMin, rangeMax), this.transform.position.y);

        //generatorの位置で生成
        StartCoroutine(MeteoGenerate(this.gameObject));

        //generatorの位置で生成
        StarGenerate(this.gameObject);
    }

    IEnumerator MeteoGenerate(GameObject generater)
    {
        //オブジェクトプール
        foreach (Transform t in m_meteoPool)
        {
            if (m_meteoTime > m_meteoInterval)
            {
                //オブジェが非アクティブなら使い回し
                if (!t.gameObject.activeSelf)
                {
                    //オブジェクトプール
                    t.SetPositionAndRotation(randomRange, generater.transform.rotation);
                    t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
                    m_meteoTime = 0f;
                }
                yield return new WaitForSeconds(m_meteoColutinInterval);
            }
        }
    }

    /// <summary>
    /// 星の生成
    /// </summary>
    /// <param name="generater">生成場所</param>
    void StarGenerate(GameObject generater)
    {
        //オブジェクトプール
        foreach (Transform t in m_starPool)
        {
            //星のインターバル
            if (m_starTime > m_starInterval)
            {
                //オブジェが非アクティブなら使い回し
                if (!t.gameObject.activeSelf)
                {
                    //生成位置をランダムに
                    t.SetPositionAndRotation(randomRange, generater.transform.rotation);
                    t.gameObject.SetActive(true);//位置と回転を設定後、アクティブにする
                }
            }
        }
    }
}
