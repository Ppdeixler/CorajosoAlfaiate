using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class PlayerAranha : MonoBehaviour
{
    private Transform player;

    private float n = 1f;

    private CinemachineVirtualCamera vCamera;
     
    private float horizontalInput;
    private float verticalInput;

    private bool morreu;
    private Transform minigame;
    private GameObject minigameobj;

    [SerializeField] private GameObject prefabTeia;

    private Inventory inventory;

    [SerializeField] private GameObject playerverdadero;
    private Transform trsPlayerverdadero;

    void Awake()
    {
        player = GetComponent<Transform>();
        GameObject invobj = GameObject.Find("Inv");
        minigame = GameObject.Find("MinigameAranha").GetComponent<Transform>();
        minigameobj = GameObject.Find("MinigameAranha");
        inventory = invobj.GetComponent<Inventory>();
        vCamera = GameObject.Find("CM vcam1").GetComponent<CinemachineVirtualCamera>();
        trsPlayerverdadero = playerverdadero.GetComponent<Transform>();


    }



    void Update()
    {
        if (morreu) return;
        playerandar();
    }


    void playerandar()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector2 p = this.transform.localPosition;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) return;

        //Bounds
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (p.y >= 2.5f) return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (p.y <= -2f) return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (p.x <= -8.5f) return;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (p.x >= -1f) return;
        }

        //Movement
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            p.y += n * verticalInput;
            player.localPosition = p;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            p.x += n * horizontalInput;
            player.localPosition = p;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "aranhamorte")
        {
            morreu = true;
            Instantiate(prefabTeia, player.position, Quaternion.identity, minigame);
            StartCoroutine(mortearanha());
        }
        if(collider.gameObject.tag == "passarin")
        {
            ganhar();
        }
    }

    void ganhar()
    {
        foreach (Item item in inventory.inventory)
        {
            if (item.itemName == "Pássaro")
            {
                item.ativo = true;
                break;
            }
        }
        minigameobj.SetActive(false);
        vCamera.Follow = trsPlayerverdadero;
        SpawnerManager.nominigame = false;
    }

    IEnumerator mortearanha()
    {
        yield return new WaitForSeconds(2f);
        {
            perder();
        }
    }

    void perder()
    {
        SpawnerManager.nominigame = false;
        SceneManager.LoadScene("Nível2_Floresta");
    }

}
