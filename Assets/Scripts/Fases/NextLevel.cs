using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private bool itemprecisa;

    [SerializeField] private string cenacarregar;

    [SerializeField] private string[] itensqueprecisa;

    private ReferenciaTrans reftrans;

    private Inventory inventory;

    [SerializeField] private AudioManager ad;

    void Awake()
    {
        GameObject invobj = GameObject.Find("Inv");
        inventory = invobj.GetComponent<Inventory>();

        ad = GameObject.Find("AudioManager").GetComponent<AudioManager>();

    }

    void Start()
    {
        reftrans = GameObject.Find("Dialogue").GetComponent<ReferenciaTrans>();
    }


    public void passardefase()
    {
        if(itemprecisa == true)
        {
            foreach(string s in itensqueprecisa)
            {
                foreach (Item itens in inventory.inventory)
                {
                    if (itens.ativo == true)
                    {
                        if (itens.itemName == s)
                        {
                            StartCoroutine(cenacarregarfuncao());
                        }
                    }
                }
            }
        }

        if(itemprecisa == false)
        {
            StartCoroutine(cenacarregarfuncao());
        }


    }

    public IEnumerator cenacarregarfuncao()
    {
        reftrans.end.SetActive(true);

        salvarinventario();
        SaveSystem.checkpointounao = false;


        yield return new WaitForSeconds(2f);

        ad.Play("Pagina");

        yield return new WaitForSeconds(0.6f);


        SceneManager.LoadScene(cenacarregar);
    }

    public void salvarinventario()
    {
        SaveSystem.salvabetween(inventory);
    }

}
