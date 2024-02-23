using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Choices : MonoBehaviour
{

    [SerializeField] private GameObject choiceSlot;
    [SerializeField] private Transform spawnParent;
    private string nomedacenaatual;

    public List<EscolhaProps> choices = new List<EscolhaProps>();

    public Inventory inventory;

    void Awake()
    {
        GameObject invobj = GameObject.Find("Inv");
        inventory = invobj.GetComponent<Inventory>();
        nomedacenaatual = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        RefreshChoice();
    }

    private void RefreshChoice()
    {
        foreach (EscolhaProps escolhas in choices)
        {
            foreach(Item itens in inventory.inventory)
            {
                if(itens.ativo == true)
                {
                    if (itens.itemName == escolhas.itemnecessario)
                    {
                        escolhas.ativofr = true;
                    }
                }
            }
            if (escolhas.ativofr == true && escolhas.instanciado == false && escolhas.cena == nomedacenaatual)
            {
                GameObject newPrefabInstance = Instantiate(choiceSlot, spawnParent);

                UI_EscolhaProps chprop = newPrefabInstance.GetComponent<UI_EscolhaProps>();

                if (chprop != null)
                {
                    chprop.SetProperties(escolhas.itemnecessario, escolhas.texto, escolhas.cena, escolhas.video, escolhas.tempoduracao, escolhas.gameover, escolhas.cenaperder, escolhas.acion, escolhas.numacion, escolhas.dialogodaacao);
                    escolhas.instanciado = true;
                }
            }
        }
    }


}
