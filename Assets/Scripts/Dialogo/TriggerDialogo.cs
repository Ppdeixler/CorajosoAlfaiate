using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    public Dialogo dialogue;


    public void Trigger()
    {
        FindObjectOfType<DialogueManager>().ComecarDialogo(dialogue);
    }




}
