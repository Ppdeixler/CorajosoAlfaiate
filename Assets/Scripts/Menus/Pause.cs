using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static bool pausado;

    [SerializeField] private GameObject menu;

    [SerializeField] private GameObject pausemenu;

    [SerializeField] private GameObject volumemenu;

    [SerializeField] private GameObject settingsmenu;

    [SerializeField] private GameObject controls;

    void Update()
    {
        pausar();
    }

    public void pausar()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (pausado == false)
            {
                pausado = true;
                menu.SetActive(true);
                pausemenu.SetActive(true);
                Debug.Log("pausar");
            }

            else
            {
                pausado = false;
                menu.SetActive(false);
                pausemenu.SetActive(false);
                Debug.Log("despausar");
            }
            


        }

    }

    public void continuar()
    {
        pausado = false;
        menu.SetActive(false);
        pausemenu.SetActive(false);
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("Menu Inicial");
    }

    public void settingss()
    {
        settingsmenu.SetActive(true);
        pausemenu.SetActive(false);
    }


    public void pausarbotao()
    {
        pausado = true;
        menu.SetActive(true);
        pausemenu.SetActive(true);
    }

}
