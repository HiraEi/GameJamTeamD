using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerM : MonoBehaviour
{
    //スキル使用のフラグ
    static bool skill1 = false; //スキル1
    static bool skill2 = false; //スキル2
    static bool skill3 = false; //スキル3

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    /// <summary>
    /// テスト用
    /// </summary>
    public void GetFlag()
    {
        skill1 = true;
        Debug.Log("スキルオン");
    }

    /// <summary>
    /// テスト用
    /// </summary>
    public void SkillActiveCheck()
    {
        Debug.Log(skill1);
    }

    /// <summary>
    /// テスト用
    /// </summary>
    public void ChangeScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    
}
