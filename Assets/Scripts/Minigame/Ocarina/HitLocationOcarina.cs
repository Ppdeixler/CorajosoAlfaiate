using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HitLocationOcarina : MonoBehaviour
{
    public static bool ocarinaon = true;

    [SerializeField] private GameObject verdeobjeto;
    private SpriteRenderer verde;
    private Color corverde;
    private bool verdebool;


    [SerializeField] private GameObject vermelhoobjeto;
    private SpriteRenderer vermelho;
    private Color corvermelho;
    private bool vermelhobool;

    void Awake()
    {
        verde = verdeobjeto.GetComponent<SpriteRenderer>();
        vermelho = vermelhoobjeto.GetComponent<SpriteRenderer>();

        corverde = verde.color;
        corvermelho = vermelho.color;

    }


    void Update()
    {
        bater();
        cores();
    }



    void cores()
    {
        if(corverde.a == 1f)
        {
            verdebool = false;
        }




        if(verdebool == true)
        {
            corverde.a += 0.1f;
        } else
        {
            corverde.a -= 0.1f;
        }
    }


    void bater()
    {

        if(TempoOcarina.nominigamewow == true)
        {
            return;
        }

        if (HitLocationOcarina.ocarinaon == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

            if(hit.collider == null)
            {
                return;
            }
            if(hit.collider.gameObject.tag != "Seta")
            {
                return;
            }

            if(hit.collider.gameObject.TryGetComponent(out SetasNumeral setasnumero))
            {
                if(setasnumero.numeroidentificar == 2)
                {
                    Destroy(hit.collider.gameObject);
                }   else
                {
                    perder();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

            if (hit.collider == null)
            {
                return;
            }
            if (hit.collider.gameObject.tag != "Seta")
            {
                return;
            }

            if (hit.collider.gameObject.TryGetComponent(out SetasNumeral setasnumero))
            {
                if (setasnumero.numeroidentificar == 1)
                {
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    perder();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

            if (hit.collider == null)
            {
                return;
            }
            if (hit.collider.gameObject.tag != "Seta")
            {
                return;
            }

            if (hit.collider.gameObject.TryGetComponent(out SetasNumeral setasnumero))
            {
                if (setasnumero.numeroidentificar == 3)
                {
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    perder();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

            if (hit.collider == null)
            {
                return;
            }
            if (hit.collider.gameObject.tag != "Seta")
            {
                return;
            }

            if (hit.collider.gameObject.TryGetComponent(out SetasNumeral setasnumero))
            {
                if (setasnumero.numeroidentificar == 4)
                {
                    verdebool = true;
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    perder();
                }
            }
        }
    }


    void perder()
    {
        SceneManager.LoadScene("Harpa");
    }

}
