using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSair : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Saida")
        {
            NextLevel nl = other.gameObject.GetComponent<NextLevel>();
            nl.passardefase();
        }
    }


}
