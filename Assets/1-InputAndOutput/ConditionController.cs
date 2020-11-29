using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionController : MonoBehaviour
{
    void Start()
    {
        // a の値によって異なる処理をする
        int a = 10;

        Debug.Log("a の中身は " + a.ToString());

        if (a == 5)
        {
            Debug.Log("a は 5 である");
        }
        else if (a > 5)
        {
            Debug.Log("a は 5 より大きい");
        }
        else
        {
            Debug.Log("a は 5 ではなく、5 より大きくもない");
        }

        // b が整数か奇数かを判断する
        int b = 17;
        Debug.Log("b の中身は " + b.ToString());

        if (b % 2 == 1)
        {
            Debug.Log(b.ToString() + " は奇数です。");
        }
        else
        {
            Debug.Log(b.ToString() + " は偶数です。");
        }

        // 課題1: 9 行目で変数 a を初期化しているが、ここで a に代入する値を変更して 20 行目が実行されるようにせよ。
        // 課題2: 変数 c (int 型) を宣言し、適当な整数を代入せよ。その c が「2 の倍数か」「3 の倍数か」「6 の倍数か」「それらのどれでもないか」を判定し、結果を出力せよ。
    }

    void Update()
    {
        
    }
}
