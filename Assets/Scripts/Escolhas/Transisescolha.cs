using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transisescolha : MonoBehaviour
{

    [SerializeField] private GameObject transisobj;
    [SerializeField] private string cenacarrega;


    public void perderwow()
    {
        StartCoroutine(transisperder());
    }

    public IEnumerator transisperder()
    {
        transisobj.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(cenacarrega);
    }
}