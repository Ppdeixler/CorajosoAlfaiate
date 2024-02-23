using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeta : MonoBehaviour
{

    [SerializeField] private GameObject setaesquerda;
    [SerializeField] private GameObject setabaixo;
    [SerializeField] private GameObject setacima;
    [SerializeField] private GameObject setadireita;

    private float randomNum;

    void Update()
    {
        spawnar();
    }

    void spawnar()
    {

        if(HitLocationOcarina.ocarinaon == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            randomNum = Random.Range(1, 5);

            if(randomNum == 1)
            {
                Instantiate(setaesquerda, transform.position, setaesquerda.transform.rotation);
            }
            if (randomNum == 2)
            {
                Instantiate(setacima, transform.position, setacima.transform.rotation);
            }
            if (randomNum == 3)
            {
                Instantiate(setabaixo, transform.position, setabaixo.transform.rotation);
            }
            if (randomNum == 4)
            {
                Instantiate(setadireita, transform.position, setadireita.transform.rotation);
            }
        }
    }
}
