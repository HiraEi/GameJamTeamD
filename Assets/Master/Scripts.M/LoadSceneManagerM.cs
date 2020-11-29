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
    /// ステージ2に遷移
    /// </summary>
    public void LoadGameSceneStage2()
    {
        SceneManager.LoadScene("GameSceneStage2");
    }

    /// <summary>
    /// ステージ3に遷移
    /// </summary>
    public void LoadGameSceneStage3()
    {
        SceneManager.LoadScene("GameSceneStage3");
    }

    /// <summary>
    /// ステージ4に遷移
    /// </summary>
    public void LoadGameSceneStage4()
    {
        SceneManager.LoadScene("GameSceneStage4");
    }

    /// <summary>
    /// クリア１に遷移
    /// </summary>
    public void LoadClearScene1()
    {
        SceneManager.LoadScene("ClearScene1");
    }

    /// <summary>
    /// クリア2に遷移
    /// </summary>
    public void LoadClearScene2()
    {
        SceneManager.LoadScene("ClearScene2");
    }

    /// <summary>
    /// クリア3に遷移
    /// </summary>
    public void LoadClearScene3()
    {
        SceneManager.LoadScene("ClearScene3");
    }

    /// <summary>
    /// クリア4に遷移
    /// </summary>
    public void LoadClearScene4()
    {
        SceneManager.LoadScene("ClearScene4");
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

    /// <summary>
    /// ゲームオーバーシーンへ遷移
    /// </summary>
    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
