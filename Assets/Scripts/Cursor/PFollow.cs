using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PFollow : MonoBehaviour
{

    private Vector2 mousePosition;

    private Transform esse;

    void Awake()
    {
        esse = GetComponent<Transform>();
    }

    void Update()
    {
        seguir();
    }

    void seguir()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        esse.position = mousePosition;

    }


    


}
