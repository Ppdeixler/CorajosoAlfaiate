using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comecojogo : MonoBehaviour
{

    [SerializeField] private float tempowow;

    [SerializeField] private string cena;

    void Awake()
    {
        StartCoroutine(comecoaaa());
    }


    IEnumerator comecoaaa()
    {
        yield return new WaitForSeconds(tempowow);

        SceneManager.LoadScene(cena);
    }

}
