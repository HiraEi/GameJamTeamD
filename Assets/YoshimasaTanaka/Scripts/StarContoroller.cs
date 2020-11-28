using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarContoroller : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
