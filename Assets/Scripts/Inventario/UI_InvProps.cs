using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_InvProps : MonoBehaviour
{

    public string nome;
    public string descricao;
    public Sprite icone;
    public bool active;

    private Image thisimage;



    public void SetProperties(string itemName, string itemDescription, bool seativo, Sprite imagem)
    {
        nome = itemName;
        descricao = itemDescription;
        active = seativo;
        icone = imagem;
        thisimage = GetComponent<Image>();
        thisimage.sprite = imagem;
    }

}
