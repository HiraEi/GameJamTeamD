using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthController : MonoBehaviour
{
    [SerializeField] int m_earthHp = 100;
    [SerializeField] int m_meteoDamage = 10;
    [SerializeField] int m_starDamage = 20;

    [SerializeField] GameObject m_backGround = default;

    [SerializeField] GameObject loadSceneObject = default;
    LoadSceneManagerM loadSceneManager;

    Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {
        loadSceneManager = loadSceneObject.GetComponent<LoadSceneManagerM>();
        m_anim = m_backGround.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (m_earthHp <= 0)
        {
            loadSceneManager.LoadGameOverScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Meteo")
        {
            m_earthHp -= m_meteoDamage;
            m_anim.Play("Damage");
            //Debug.Log("EarthHP" + m_earthHp);
        }
        else if (collision.tag == "Star")
        {
            m_earthHp -= m_starDamage;
            m_anim.Play("Damage");
            //Debug.Log("EarthHP" + m_earthHp);
        }
    }
}
