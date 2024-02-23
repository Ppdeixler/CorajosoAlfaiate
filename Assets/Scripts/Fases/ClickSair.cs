using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSair : MonoBehaviour
{


    private Vector2 mousePosition;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        clickarprasair();
    }

    void clickarprasair()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider == null) { return; }
            if (hit.collider.gameObject == null) { return; }


            if (hit.collider.gameObject.tag == "Saida")
            {
                NextLevel nl = hit.collider.gameObject.GetComponent<NextLevel>();
                nl.passardefase();
            }
        }
    }
}
