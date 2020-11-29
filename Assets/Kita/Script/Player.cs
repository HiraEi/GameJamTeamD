using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // 移動速度
    [SerializeField]
    float moveSpeedX = 10.0f;

    [SerializeField]
    float moveSpeedY = 10.0f;

    // 3D空間の横幅
    [SerializeField]
    float width = 1.0f;

    // 3D空間の縦幅
    [SerializeField]
    float height = 1.0f;

	public GameObject score_object = null; // Textオブジェクト
	int number = 12;
	Constellation1 p_Constellation;


	void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
		// 移動
		UpdateMove();
		// オブジェクトからTextコンポーネントを取得
		Text score_text = score_object.GetComponent<Text>();
		// テキストの表示を入れ替える
		score_text.text = "あと" + number;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			number--;
		}
	}

	/// <summary>
	/// 移動処理
	/// </summary>
	void UpdateMove()
	{
		// 一度、変数の格納する。
		// transform.position.x += 1.0f これはできない為！
		Vector3 position = transform.position;

		// 移動入力
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			// Time.deltaTime：処理落ちがあっても、移動量が変わらないようにする為に使用している。
			position.x -= moveSpeedX * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			position.x += moveSpeedX * Time.deltaTime;
		}

		// 反映
		transform.position = position;
	}
}
