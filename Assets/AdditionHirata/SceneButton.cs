using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    AudioSource m_audio;
    [SerializeField] AudioClip m_audioClip = default;
    [SerializeField] float m_waitTime = 1f;

    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
    }


    /// <summary>
    /// ルールシーンへ遷移
    /// </summary>
    public void LoadExplanation()
    {
        StartCoroutine("WaitForLoadSccene");
    }

    //コルーチン
    IEnumerator WaitForLoadSccene()
    {
        //m_audio.PlayOneShot(m_audioClip);
        yield return new WaitForSeconds(m_waitTime);
        SceneManager.LoadScene("ExplanationScene");
    }

    /// <summary>
    /// ゲームシーン1へ遷移
    /// </summary>
    public void LoadGameScene()
    {
        StartCoroutine("WaitForLoadSccene1");
    }

    IEnumerator WaitForLoadSccene1()
    {
        //m_audio.Play();
        yield return new WaitForSeconds(m_waitTime);
        SceneManager.LoadScene("GameScene");
    }

    /// <summary>
    /// ステージ2に遷移
    /// </summary>
    public void LoadGameSceneStage2()
    {
        StartCoroutine("WaitForLoadSccene2");
    }

    IEnumerator WaitForLoadSccene2()
    {
        //m_audio.PlayOneShot(m_audioClip);
        yield return new WaitForSeconds(m_waitTime);
        SceneManager.LoadScene("GameSceneStage2");
    }

    /// <summary>
    /// ステージ3に遷移
    /// </summary>
    public void LoadGameSceneStage3()
    {
        StartCoroutine("WaitForLoadSccene3");
    }

    IEnumerator WaitForLoadSccene3()
    {
        //m_audio.PlayOneShot(m_audioClip);
        yield return new WaitForSeconds(m_waitTime);
        SceneManager.LoadScene("GameSceneStage3");
    }

    /// <summary>
    /// ステージ4に遷移
    /// </summary>
    public void LoadGameSceneStage4()
    {
        StartCoroutine("WaitForLoadSccene4");
    }

    IEnumerator WaitForLoadSccene4()
    {
        //m_audio.PlayOneShot(m_audioClip);
        yield return new WaitForSeconds(m_waitTime);
        SceneManager.LoadScene("GameSceneStage4");
    }

    /// <summary>
    /// リザルトシーンへ遷移
    /// </summary>
    public void LoadResultScene()
    {
        StartCoroutine("WaitForLoadScceneResult");
    }

    IEnumerator WaitForLoadScceneResult()
    {
        //m_audio.PlayOneShot(m_audioClip);
        yield return new WaitForSeconds(m_waitTime);
        SceneManager.LoadScene("ResultScene");
    }

    /// <summary>
    /// ステージセレクトシーンへ遷移
    /// </summary>
    public void LoadStageSelectScene()
    {
        StartCoroutine("WaitForLoadScceneStageSelect");
    }

    IEnumerator WaitForLoadScceneStageSelect()
    {
        //m_audio.PlayOneShot(m_audioClip);
        yield return new WaitForSeconds(m_waitTime);
        SceneManager.LoadScene("StageSelectScene");
    }

    /// <summary>
    /// ゲームオーバーシーンへ遷移
    /// </summary>
    public void LoadGameOverScene()
    {
        StartCoroutine("WaitForLoadScceneGameOver");
    }

    IEnumerator WaitForLoadScceneGameOver()
    {
        //m_audio.PlayOneShot(m_audioClip);
        yield return new WaitForSeconds(m_waitTime);
        SceneManager.LoadScene("GameOverScene");
    }

    /// <summary>
    /// タイトルシーンへ遷移
    /// </summary>
    public void LoadTittleScene()
    {
        StartCoroutine("WaitForLoadScceneTittleScene");
    }

    IEnumerator WaitForLoadScceneTittleScene()
    {
        //m_audio.PlayOneShot(m_audioClip);
        yield return new WaitForSeconds(m_waitTime);
        SceneManager.LoadScene("TitleScene");
    }
}
