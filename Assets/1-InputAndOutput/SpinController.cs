using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour
{
    void Start()
    {
        Debug.Log(Vector3.forward.ToString());  // Update() 内で使っている Vector3.forward が何なのか出力する
    }

    void Update()
    {
        Transform t = this.gameObject.transform;    // このオブジェクトが追加されているオブジェクトのトランスフォームを取得する
        t.Rotate(Vector3.forward, 0.1f);    // Z軸を中心に 0.1 ずつ回転させる。これは関数を呼んでいる。
    }
}
