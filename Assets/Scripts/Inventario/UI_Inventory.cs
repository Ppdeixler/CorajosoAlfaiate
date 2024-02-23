using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private GameObject invobj;

    [SerializeField] private Transform spawnParent;
    [SerializeField] private GameObject itemSlot;


    void Awake()
    {
        invobj = GameObject.Find("Inv");
        inventory = invobj.GetComponent<Inventory>();

        RefreshInventoryItems();
    }


    void Update()
    {
        RefreshInventoryItems();
    }





    private void RefreshInventoryItems()
    {
        foreach (Item item in inventory.inventory)
        {
            if (item.ativo == true && item.instanciado == false)
            {
                GameObject newPrefabInstance = Instantiate(itemSlot, spawnParent);

                UI_InvProps invprop = newPrefabInstance.GetComponent<UI_InvProps>();

                if (invprop != null)
                {
                    invprop.SetProperties(item.itemName, item.itemDescription, item.ativo, item.itemIcon);
                    item.instanciado = true;
                }
            }
        }
    }

}
