using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UniAnim : MonoBehaviour
{
    Animator animator;

    [SerializeField] private GameObject minigame;

    [SerializeField] private DragManager dManager;

    private bool fada = false;

    private bool trigou;
    void Awake()
    {
        //GameObject unicornio = GameObject.Find("EmoUnicorn");
        //animator = unicornio.GetComponent<Animator>();
        //Animation animation = unicornio.GetComponent<Animation>();
        trigou = false;
    }



    void Update()
    {

    }

    public void trigarnormal()
    {
        if(fada == false)
        {
           minigame.SetActive(true);
           SpawnerManager.nominigame = true;
           fada = true;
        }

    }

    public void trigmini()
    {

        if(dManager.dTrig == 3)
        {
            SceneManager.LoadScene("Fim");
        }


        Debug.Log("Clickobotao");
        dManager.comecoomgwow();
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponent<Animation>().Stop();
        }
    } 
}
