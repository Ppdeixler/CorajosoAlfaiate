using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirMenuS : MonoBehaviour
{


    [SerializeField] private GameObject menuquevaiabrir;
    [SerializeField] private GameObject menuquevaifechar;

    public void abrirmenu()
    {
        menuquevaiabrir.SetActive(true);
    }

    public void fecharmenu()
    {
        menuquevaifechar.SetActive(false);
    }


}
