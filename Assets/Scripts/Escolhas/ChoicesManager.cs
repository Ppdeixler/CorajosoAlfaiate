using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesManager : MonoBehaviour
{

    [SerializeField] public GameObject[] gridschoices;

    public void ativarchoices(int numero)
    {
        gridschoices[numero].SetActive(true);
    }
}
