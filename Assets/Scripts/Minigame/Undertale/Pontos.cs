using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Pontos : MonoBehaviour
{

    public int pontos;
    public TextMeshProUGUI textScore;


    void Start()
    {

    }

    void Update()
    {
        textScore.text = pontos.ToString();
    }

    public void aumentarponto()
    {
        pontos += 1;
    }
}
