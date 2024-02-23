using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlAnimSc : MonoBehaviour
{

    private Animator anim;

    private bool correndo;

    void Awake()
    {
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        pegarInfo();
    }


    void pegarInfo()
    {
        if(SpawnerManager.nominigame == true || DialogueManager.falando == true)
        {
            anim.SetBool("Correndo", false);
            return;
        }



        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Correndo", true);
        }
        else
        {
            anim.SetBool("Correndo", false);
        }
    }


}
