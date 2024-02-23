using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{


    public int dTrig = 0;

    public GameObject grid;
    public GameObject grid2;
    public GameObject grid3;

    public GameObject cutsceness;

    public bool gridativo;

    [SerializeField] SpawnerManager sm;

    [SerializeField] private GameObject minigame;

    public bool videoativo;

    [SerializeField] public GameObject[] prefabsTexto;

    [SerializeField] private PlayerDragao pd;


    [SerializeField] private GameObject harpa;

    private Inventory inventory;

    void Awake()
    {
        inventory = GameObject.Find("Inv").GetComponent<Inventory>();
        dTrig = 0;
    }



    void Update()
    {

        foreach (Item item in inventory.inventory)
        {
            if (item.itemName == "Harpa")
            {
                if (item.ativo == true)
                {
                    harpa.SetActive(true);
                }
                else
                {
                    harpa.SetActive(false);
                }
            }
        }






        grid = GameObject.Find("Escolhas").transform.GetChild(0).gameObject;
        grid2 = GameObject.Find("Escolhas").transform.GetChild(1).gameObject;
        grid3 = GameObject.Find("Escolhas").transform.GetChild(2).gameObject;

        if (grid.activeSelf || grid2.activeSelf || grid3.activeSelf)
        {
            gridativo = true;
        }
        if (!grid.activeSelf && !grid2.activeSelf && !grid3.activeSelf)
        {
            gridativo = false;
        }


        if (!cutsceness.activeSelf)
        {
            videoativo = false;
        } else videoativo = true;

        condicao();

        if (minigame.activeSelf)
        {
            SpawnerManager.nominigame = true;
        }
        else SpawnerManager.nominigame = false;

    }

    public void comecoomgwow()
    {
        StartCoroutine(triggarminigameuni());
    }


    public IEnumerator triggarminigameuni()
    {
        Debug.Log(gridativo);
        yield return new WaitForSeconds(0.2f);
       // Debug.Log("1");
        yield return new WaitUntil(() => condicao() == false);

        //Debug.Log("2");
        minigame.SetActive(true);

        yield return new WaitForSeconds(2f);
        //Debug.Log("3");
        
        sm.comecartudo();
        dTrig++;
        Debug.Log(dTrig);
        StopAllCoroutines();

        StartCoroutine(pd.contadora());
    }

    public bool condicao()
    {
        if (gridativo || videoativo || DialogueManager.falando) { return true; Debug.Log("Barrando"); } else return false; Debug.Log("Oga");
    }




}
