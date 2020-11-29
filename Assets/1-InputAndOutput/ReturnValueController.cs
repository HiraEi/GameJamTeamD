using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnValueController : MonoBehaviour
{
    void Start()
    {
        // 関数の引数・戻り値の例
        int a = Mathf.Max(1, 3);    // 与えた引数の内、最大のものを返す関数。Mathf は色々な数学の関数が呼べる「クラス（静的クラス）」です。
        Debug.Log(a);
        float b = Mathf.Min(1.5f, 0.8f);    // 最小のものを返す関数
        Debug.Log(b);
    }

    
    void Update()
    {
        float t = Time.time;    // Time.time は現在時刻を float で表現したもの。Time は時間に関係した情報が得られる「クラス（静的クラス）」です。
        Vector2 p = Vector2.zero;   // p は position の p。座標をこれから設定する。
        p.x = Mathf.Sin(t); // x 座標を計算する
        p.y = Mathf.Cos(t); // y 座標を計算する
        this.transform.position = p;    // このスクリプトコンポーネントがアタッチされたオブジェクトの座標を設定している。
    }
}
