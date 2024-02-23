using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrans : MonoBehaviour
{


    void Awake()
    {
        StartCoroutine(comecouga());
    }


     IEnumerator comecouga()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }

}
