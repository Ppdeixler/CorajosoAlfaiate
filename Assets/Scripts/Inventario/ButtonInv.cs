using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInv : MonoBehaviour
{
    [SerializeField] private GameObject inventario;


    public void ativadesativa()
    {
        if (inventario.activeSelf)
        { inventario.SetActive(false); } 
        else { inventario.SetActive(true); }
    }





}
