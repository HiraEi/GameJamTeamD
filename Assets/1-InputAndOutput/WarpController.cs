using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpController : MonoBehaviour
{
    void Start()
    {
        Vector2 v2 = Vector2.zero;  // v2 = (0, 0) である。zero は Vector2 のプロパティであり、Vector2.zero は (0, 0) を表す。
        Debug.Log(v2.ToString());   // v2 が何か出力する
        Transform t = this.gameObject.transform;    // このオブジェクトが追加されているオブジェクトのトランスフォームを取得する
        t.position = v2;    // position（= 位置/座標）を書き変える。position は Transform 型の変数 t のプロパティで、オブジェクトの位置（座標）を表す。型は Vector2 または Vector3 である。
    }

    void Update()
    {
        
    }
}
