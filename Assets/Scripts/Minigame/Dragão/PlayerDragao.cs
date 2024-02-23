using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayerDragao : MonoBehaviour
{

    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float speed;

    [SerializeField] private Transform canvasdebug;

    private Vector2 movimentorb;

    [SerializeField] private GameObject debugperdeu;

    [SerializeField] private GameObject minigame;

    [SerializeField] private GameObject prefabDialoguedps;

    [SerializeField] private Transform prefabLugar;

    [SerializeField] private SpawnerManager sm;

    [SerializeField] private DragManager dm;

    [SerializeField] private VideoPlayer fim;
    [SerializeField] private float fimtempo;
    private GameObject player;
    private BoxCollider2D bc2d;

    private bool banana = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "InimigoDragao")
        {
            Debug.Log("perdeu");
            SpawnerManager.nominigame = false;
            SceneManager.LoadScene("Nível_9Caverna");
        }
    }

    void Start()
    {
        player = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(contadora());
        bc2d = player.GetComponent<BoxCollider2D>();
    }


    void Update()
    {


        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        movimentorb = new Vector2(horizontalInput, verticalInput).normalized * speed;
        rb.velocity = movimentorb;

        if (dm.dTrig == 4 && banana == false)
        {
            StartCoroutine(acabarojogo());
            banana = true;
        }

    }


    public IEnumerator contadora()
    {

        yield return new WaitForSeconds(10f);
        venceu();
    }

    void venceu()
    {

        if(dm.dTrig == 4)
        {
            StartCoroutine(acabarojogo());
        }

        minigame.SetActive(false);
        Instantiate(dm.prefabsTexto[dm.dTrig - 1], prefabLugar);
        Debug.Log("instanciou");
        bc2d.enabled = true;
        SpawnerManager.nominigame = false;
    }


    public IEnumerator acabarojogo()
    {
        fim.Play();
        yield return new WaitForSeconds(fimtempo);
        SceneManager.LoadScene("Menu Inicial");
    }


}
