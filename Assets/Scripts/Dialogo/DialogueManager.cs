using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogueManager : MonoBehaviour
{
    public static bool falando;

    public bool aceitarnegar;

    public bool troca;

    public Queue<string> falas;

    [SerializeField] private GameObject UIDialogo;

    public TextMeshProUGUI nomeText;
    public TextMeshProUGUI dialogoText;

    public Inventory inventory;

    public ChoicesManager CM;

    private Vector2 mouseP;

    public string[] itensreceber;
    public string[] itensretirar;

    [SerializeField] private float delayLetras;

    private bool f = true;

    private bool invobj;

    void Start()
    {
        falas = new Queue<string>();
        falando = false;

        GameObject invobj = GameObject.Find("Inv");
        inventory = invobj.GetComponent<Inventory>();

        CM = GameObject.Find("Escolhas").GetComponent<ChoicesManager>();
    }

    private Dialogo dl;

    public void ComecarDialogo(Dialogo dialogo)
    {
        dl = dialogo;

        if (dialogo.falouja == true)
        {
            return;
        }

        falando = true;
        UIDialogo.SetActive(true);

        nomeText.text = dialogo.nome;

        foreach (string fala in dialogo.dialogos)
        {
            falas.Enqueue(fala);
        }

        if (dialogo.aceitaritem == true)
        {
            aceitarnegar = true;
        }

        if(dialogo.trocaritem == true)
        {
            troca = true;
        }

        ContinuarFala();

        dialogo.falouja = true;

    }           

    public void DarItens()
    {
        foreach (string itensquevaireceber in itensreceber)
        {
            foreach(Item itensdoinv in inventory.inventory)
            {
                if(itensquevaireceber == itensdoinv.itemName)
                {
                    itensdoinv.ativo = true;
                    break;
                }
            }
        }
    }


    public void trocar()
    {
        foreach(string itensquevaiperder in itensretirar)
        {
            foreach (Item itensdoinv in inventory.inventory)
            {
                if (itensquevaiperder == itensdoinv.itemName)
                {
                    if(itensdoinv.ativo == false)
                    {
                        f = false;
                        Debug.Log("UGAUBGA");
                        break;
                        return;
                    }
                }
            }
        }
        if (f = true)
        {
            DarItens();
            StartCoroutine(TirarItens());
        }
    }

    public void MostrarQNtem()
    {

    }

    public IEnumerator TirarItens()
    {

        foreach (string itensquevaiperder in itensretirar)
        {
            foreach (Item itensdoinv in inventory.inventory)
            {
                if(itensdoinv.itemName == itensquevaiperder)
                {
                    if(itensdoinv.ativo == false)
                    {
                        Debug.Log(itensdoinv.itemName);
                        MostrarQNtem();
                        break;
                    }
                }

                if (itensquevaiperder == itensdoinv.itemName)
                {
                    itensdoinv.ativo = false;
                    itensdoinv.instanciado = false;

                    Debug.Log("AAAAAA");

                    yield return new WaitUntil(() => invobj);

                    foreach (Transform slots in GameObject.Find("InventoryPanel").transform)
                    {
                        if (slots.TryGetComponent<UI_InvProps>(out UI_InvProps itemProps))
                        {
                            if (itemProps.nome == itensquevaiperder)
                            {
                                Destroy(slots.gameObject);
                            }
                        }
                    }

                    break;
                }
            }
        }
    }

    private IEnumerator WaitForInventoryPanel()
    {
        while (GameObject.Find("InventoryPanel") == null)
        {
            yield return null;
        }
    }

    public void ContinuarFala()
    {

        if(falas.Count == 0)
        {
            if(aceitarnegar == true && troca == false)
            {
                DarItens();
            }

            if(troca == true)
            {
                trocar();
            }

            if(dl.acaodialogo == true)
            {
                ChoicesManager c = GameObject.Find("Escolhas").GetComponent<ChoicesManager>();
                GameObject go = c.gridschoices[dl.numeroacaotrig];
                go.SetActive(true);
            }

            UIDialogo.SetActive(false);
            falas.Clear();
            falando = false;
            return;
        }

        string fala = falas.Dequeue();
        StopAllCoroutines();
        StartCoroutine(type(fala));
    }


    public void triggaracao()
    {

    }



    IEnumerator type(string fala)
    {
        dialogoText.text = "";
        foreach(char letra in fala.ToCharArray())
        {
            dialogoText.text += letra;
            yield return new WaitForSeconds(delayLetras);
        }
    }


    void Update()
    {
        if (GameObject.Find("InventoryPanel") == null)
        {
            invobj = false;
        } else invobj = true;
        mouseP = Input.mousePosition;
        MouseNpc();
    }

    public void MouseNpc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(mouseP);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider == null)
            {
                return;
            }

            if (hit.collider.gameObject.tag == "npc" && falando == false)
            {
                GameObject npc = hit.collider.gameObject;

                npc.GetComponent<TriggerDialogo>().Trigger();
            }

        }
    }



}
