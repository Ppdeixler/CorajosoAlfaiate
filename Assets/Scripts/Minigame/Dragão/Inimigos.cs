using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigos : MonoBehaviour
{
    private GameObject player;

    private Rigidbody2D rb;

    [SerializeField] private float velocidadeprojetil;

    private float angle;
    private Vector2 direction;

    private bool lancado = false;

    void Awake()
    {
        player = GameObject.Find("PlayerDragao");

        rb = GetComponent<Rigidbody2D>();

        direcao();

        StartCoroutine(lancar());

        Destroy(this.gameObject, 5f);
        pegardirecao();


    }

    void Update()
    {
        if (velocidadeprojetil == 7f)
        {
            velocidadeprojetil = 7f;
            return;
        }
        

        if(lancado == true)
        {
            velocidadeprojetil = velocidadeprojetil += 5f * Time.deltaTime;
            rb.velocity = direction * velocidadeprojetil;
        }

    }


    private void pegardirecao()
    {
        angle = transform.rotation.eulerAngles.z + 90f;

        direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
    }

    private void lancarbola()
    {
        float angle = transform.rotation.eulerAngles.z + 90f;

        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
        rb.velocity = direction * velocidadeprojetil;

        lancado = true;

    }

    IEnumerator lancar()
    {
        yield return new WaitForSeconds(1f);
        lancarbola();
    }


    private void direcao()
    {
        Vector2 direction = player.transform.position - this.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        this.transform.rotation = rotation;

    }
}
