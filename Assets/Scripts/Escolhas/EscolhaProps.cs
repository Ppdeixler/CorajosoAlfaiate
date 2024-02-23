using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
[System.Serializable]
public class EscolhaProps
{
    public string itemnecessario;
    public string cena;
    public string texto;
    public VideoPlayer video;
    public bool ativofr;
    public bool instanciado;
    public float tempoduracao;
    public bool gameover;
    public string cenaperder;

    public bool acion;
    public int numacion;

    public Dialogo dialogodaacao;
}
