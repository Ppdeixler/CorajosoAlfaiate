using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


[System.Serializable]
public class InvSave
{

    public float posicao;
    public string[] itensarmazem;
    public string cenasalva;
    public int itensqueexistem;
    public int i = 0;

    public InvSave(Inventory inv)
    {
        cenasalva = SceneManager.GetActiveScene().name;

        itensarmazem = new string[inv.inventory.Count];
        

        foreach (Item item in inv.inventory)
        {
            if(item.ativo == true)
            {
                    itensarmazem[i] = item.itemName;
                    i++;
            }
        }

        i = 0;
    }
}
