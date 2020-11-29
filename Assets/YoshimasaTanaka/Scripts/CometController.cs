using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometController : MonoBehaviour
{
    /// <summary>爆発エフェクトのプレハブ</summary>
    [SerializeField] GameObject m_explosionPrefab = null;

    [SerializeField] float m_lifeTime = 0.2f;
    public bool m_isDead = false;
    float m_timer;

    /* public void BreakThis()
     {

     }*/

    public IEnumerator BreakThis()
    {
        Debug.Log($"呼ばれた{m_isDead}");
        if (m_isDead)
        {
            StartCoroutine("Destruction");
            yield return new WaitForSeconds(0.2f);
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject, 0.2f);

        }
    }

    public IEnumerator Destruction()
    {
        Debug.Log("Called");
        if (m_isDead)
        {
            yield return new WaitForSeconds(0.18f);
            Instantiate(m_explosionPrefab, this.transform.position, m_explosionPrefab.transform.rotation);
        }
    }
}
