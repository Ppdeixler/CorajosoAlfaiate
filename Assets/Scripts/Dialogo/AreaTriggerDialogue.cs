using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaTriggerDialogue : MonoBehaviour
{










    void OnTriggerEnter2D(Collider2D other)
    {

            if(other.gameObject.tag == "salvaarea")
        {
            AreaSave areasave = other.gameObject.GetComponent<AreaSave>();

            Debug.Log("Salvou!");

            areasave.salvarcheckpoint();
        }

            if (other.gameObject.tag == "npcarea" && DialogueManager.falando == false)
            {
                GameObject npc = other.gameObject;

                npc.GetComponent<TriggerDialogo>().Trigger();
            }
    }
}
