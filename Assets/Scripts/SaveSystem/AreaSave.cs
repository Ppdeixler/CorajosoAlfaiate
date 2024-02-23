using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSave : MonoBehaviour
{
    Inventory inventory;

    void Awake()
    {
        inventory = GameObject.Find("Inv").GetComponent<Inventory>();
    }

    public void salvarcheckpoint()
    {
        inventory.salvarcheckpoint();
    }

}
