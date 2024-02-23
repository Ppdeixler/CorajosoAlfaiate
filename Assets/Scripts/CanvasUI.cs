using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasUI : MonoBehaviour
{

    private Canvas canvasui;

    void Awake()
    {
        canvasui = GetComponent<Canvas>();
        canvasui.worldCamera = Camera.main;
    }



}
