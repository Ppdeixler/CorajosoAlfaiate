using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Dodgebar : MonoBehaviour
{
    [SerializeField] private Vector2 posicao;
    [SerializeField] private GameObject dodgeamarelo;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private Button botao;
    private bool tadentro = false;
    private Pontos pontuacao;
    [SerializeField] private GameObject pontosobject;
    private Transform playerT;
    [SerializeField] private GameObject prefabDialogo;
    [SerializeField] private GameObject minigame;

    [SerializeField] private GameObject unicornio;

    [SerializeField] private GameObject transisobj;

    private bool trigou;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        pontuacao = pontosobject.GetComponent<Pontos>();
        GameObject player = GameObject.Find("Player");
        playerT = player.transform;
        começar();
    }

    void Update()
    {
        Debug.Log(tadentro);
        rb.velocity = new Vector2(speed, 0f);


        parar();
    }

    public void começar()
    {
        speed = Random.Range(7f, 10f);
        dodgeamarelo.transform.position = new Vector2(Random.Range(-7.33f, -2.3f), -1.89f);
        this.transform.position = posicao;
        botao.interactable = false;



    }

    void parar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            speed = 0f;
            botao.interactable = true;
            if (tadentro == true) { minigame.SetActive(false); if (trigou == false){ Instantiate(prefabDialogo); trigou = true; } SpawnerManager.nominigame = false; unicornio.SetActive(false); }
            else { pontuacao.pontos = 0; StartCoroutine(transisperder()); }
        }
    }
    

    IEnumerator transisperder()
    {
        transisobj.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Nível7_Unicórnio");
    }

    void pararsozin()
    {
        speed = 0f;
        botao.interactable = true;
        if (tadentro == true) { minigame.SetActive(false); if (trigou == false){ Instantiate(prefabDialogo); trigou = true; } SpawnerManager.nominigame = false; unicornio.SetActive(false); }
        else { pontuacao.pontos = 0; StartCoroutine(transisperder()); }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "dodgebar")
        {
            tadentro = true;
        }

        if(other.gameObject.tag == "fimuni")
        {
            pararsozin();
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        tadentro = false;



    }



}
