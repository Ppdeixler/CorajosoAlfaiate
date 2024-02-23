using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetasNumeral : MonoBehaviour
{

    private GameObject minigameocarina;

    public int numeroidentificar;

    private Transform transformseta;

    private Vector2 thistransformposition;

    void Start()
    {
        minigameocarina = GameObject.Find("MinigameOcarina");
        this.transform.SetParent(minigameocarina.transform);
    }

    void Update()
    {
        transformseta = this.gameObject.GetComponent<Transform>();
        thistransformposition = transformseta.position;
        andar();
    }

    void andar()
    {
        if(HitLocationOcarina.ocarinaon == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            this.transform.position = new Vector2(thistransformposition.x -= 1.5f,thistransformposition.y);
        }

    }
}
