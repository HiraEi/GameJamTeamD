using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 各シーンの遷移を行うクラス
/// ボタンに設定して使ってください
/// </summary>
public class LoadSceneManagerM : MonoBehaviour
{
    /// <summary>
    /// ルールシーンへ遷移
    /// </summary>
    public void LoadExplanation()
    {
        SceneManager.LoadScene("ExplanationScene");
    }

    /// <summary>
    /// ゲームシーンへ遷移
    /// </summary>
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// リザルトシーンへ遷移
    /// </summary>
    public void LoadResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }

    /// <summary>
    /// ステージセレクトシーンへ遷移
    /// </summary>
    public void LoadStageSelectScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
