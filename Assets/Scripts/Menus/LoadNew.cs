using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNew : MonoBehaviour
{
    [SerializeField] private string cenaqueiracarregar;


    public void newgame()
    {
        SceneManager.LoadScene(cenaqueiracarregar);
        SpawnerManager.nominigame = false;
    }

    public void carregargame()
    {
        InvSave dados = SaveSystem.carregajogo();




        SceneManager.LoadScene(dados.cenasalva);


    }

}
