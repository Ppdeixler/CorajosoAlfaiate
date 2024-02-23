using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LTscript : MonoBehaviour
{


    public string textoperder;

    private int contagem = 0;

    public TextMeshProUGUI textoTMPRO;

    [SerializeField] private float delayLetras;


    void Awake()
    {
        StartCoroutine(textinho(textoperder));
    }


    IEnumerator textinho(string textoquevaiaparecer)
    {
        yield return new WaitForSeconds(1f);
        textoTMPRO.text = "";
        foreach (char letra in textoperder.ToCharArray())
        {

            if(contagem == 6)
            {
                contagem++;
                yield return new WaitForSeconds(1.5f);
            }

            contagem++;
            textoTMPRO.text += letra;
            yield return new WaitForSeconds(delayLetras);
        }
    }



}
