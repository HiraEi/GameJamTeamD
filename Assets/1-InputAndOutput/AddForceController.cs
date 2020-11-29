using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();   // こうすると、「このオブジェクトがアタッチされている GameObject に同じようにアタッチされているコンポーネント」を取ってくることができる。
        rb.AddForce((Vector2.left + Vector2.up) * 2);   // これは「関数」を呼んでいる。関数の機能は「指定された方向に力を加える」である。
    }
}
