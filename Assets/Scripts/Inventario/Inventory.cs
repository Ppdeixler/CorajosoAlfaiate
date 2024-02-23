using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();

    private Vector2 mousePosition;

    private Camera mainCamera;

    private string ativarNome;

    [SerializeField]
    private string nomeitemminigame;

    [SerializeField]
    private GameObject minigamequevaitriggar;
    private Transform centrominigame;
    //Cinemachine
    private CinemachineVirtualCamera vCamera;
    [SerializeField]
    private GameObject centrominigameobj;
    private Transform centrominigametrs;

    [SerializeField] private GameObject prefabPoof;

    private AudioManager manageraudio;


    void Awake()
    {

        manageraudio = GameObject.Find("AudioManager").GetComponent<AudioManager>();

        mainCamera = Camera.main;
        vCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();

        if(centrominigameobj != null)
        {
            centrominigametrs = centrominigameobj.GetComponent<Transform>();
        }


        if (SceneManager.GetActiveScene().name == "Nível1_Casa")
        {
            return;
        }

        if(SaveSystem.checkpointounao == true )
        {
            Debug.Log("checkpoint");
            carregarcheckpoint();
        } else
        {
            Debug.Log("normal");
            carregarinventario();
        }
        



    }



    void Update()
    {
        
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if(hit.collider == null ) { return; }
            if(hit.collider.gameObject == null ) { return; }


            if(hit.collider.gameObject.tag == "Item")
            {
                ItemNome nomedoitem = hit.collider.gameObject.GetComponent<ItemNome>();

                Instantiate(prefabPoof, mousePosition, Quaternion.identity);

                ativarNome = nomedoitem.nome;

                salvarinventario();

                Destroy(hit.collider.gameObject);

                manageraudio.Play("Item");

                foreach(Item item in inventory)
                {
                    if(nomedoitem.nome == nomeitemminigame)
                    {
                        
                          triggarminigame();
                         return;
                        
                    }




                    if(item.itemName == nomedoitem.nome)
                    {
                        item.ativo = true;
                        salvarinventario();
                        break;
                    }
                }

            }
            

        }






    }

    private void triggarminigame()
    {
        Debug.Log("rblox");
        minigamequevaitriggar.SetActive(true);
        SpawnerManager.nominigame = true;
        vCamera.Follow = centrominigametrs;
    }

    public void salvarinventario()
    {
        SaveSystem.salvabetween(this);
    }

    public void salvarcheckpoint()
    {
        SaveSystem.salvajogo(this);
    }

    public void carregarcheckpoint()
    {

        InvSave dados = SaveSystem.carregajogo();

        foreach (Item item in inventory)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (dados.itensarmazem[i] == item.itemName)
                {
                    item.ativo = true;
                }
            }
        }
    }

    public void carregarinventario()
    {
        InvSave between = SaveSystem.carregabetween();

        foreach (Item item in inventory)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (between.itensarmazem[i] == item.itemName)
                {
                    item.ativo = true;
                }
            }
        }
    }

}
