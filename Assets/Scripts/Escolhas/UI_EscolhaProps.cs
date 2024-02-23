using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class UI_EscolhaProps : MonoBehaviour
{


    public string nomeitem;
    public string cenaagora;
    public string textoaparecer;
    public bool instanciado;
    public VideoPlayer videoplayer;
    public TextMeshProUGUI textmeshpro;
    public Transform objTextPai;
    public Transform objTextFilho;
    public GameObject obj;
    public bool vaiperder;
    public string cenacarrega;

    public bool maisacao;
    public int acaoquevaitrigar;

    public float duracaovideo;

    public Dialogo dialogosetado;

    [SerializeField] private GameObject videoObj;

    private GameObject transisobj;

    void Awake()
    {
        videoObj = GameObject.Find("Actions").GetComponent<Video>().cutscene;
        if (videoObj == null) { return; }
        videoObj.SetActive(false);
    }

    void Start()
    {
        videoObj = GameObject.Find("Actions").GetComponent<Video>().cutscene;
        if (videoObj == null) { return; }
        videoObj.SetActive(false);
        transisobj = GameObject.Find("Actions").GetComponent<Video>().transisobj;
    }


    public void SetProperties(string itemName, string textozin, string cenazin, VideoPlayer videozin, float duracaozin, bool perder, string cenalose, bool acaomais, int numeroacao, Dialogo dAcao)
    {
        objTextPai = this.gameObject.transform;
        objTextFilho = objTextPai.Find("Texto");
        obj = objTextFilho.gameObject;

        duracaovideo = duracaozin;

        vaiperder = perder;

        cenacarrega = cenalose;

        nomeitem = itemName;

        maisacao = acaomais;

        acaoquevaitrigar = numeroacao;

        dialogosetado = dAcao;

        textoaparecer = textozin;
        textmeshpro = obj.GetComponent<TextMeshProUGUI>();
        textmeshpro.text = textoaparecer;

        cenaagora = cenazin;

        videoplayer = GetComponent<VideoPlayer>();
        videoplayer.clip = videozin.clip;

    }



    public void cutscene()
    {
        
        StartCoroutine(tiravideo(duracaovideo));
        videoObj.SetActive(true);
        videoplayer.Play();
        if(maisacao == true)
        {
            DialogoAcao D_A = GetComponent<DialogoAcao>();
            D_A.trigar();
        }

        if(videoObj == null) { return; }

        RectTransform rt = transform.parent.gameObject.GetComponent<RectTransform>();
        rt.position = new Vector2(rt.position.x, 1000f);

    }

 IEnumerator tiravideo(float tempo)
    {
        yield return new WaitForSeconds(tempo);

        if (vaiperder == true)
        {
            Transisescolha te = GameObject.Find("Actions").GetComponent<Transisescolha>();
            te.perderwow();
        }

        this.transform.parent.gameObject.SetActive(false);
        if (videoObj != null)
        {
            videoObj.SetActive(false);
            this.transform.parent.gameObject.SetActive(false);
        }
        videoplayer.Stop();

    }

    IEnumerator transisperder()
    {
        transisobj.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(cenacarrega);
    }


}
