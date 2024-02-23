using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private float speed;

    private Transform playertransform;

    private Rigidbody2D rb;

    private Vector2 movimentorb;

    [SerializeField] private Vector2 playercords;
    
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        playertransform = player.GetComponent<Transform>();

        player = this.gameObject;

        SpawnerManager.nominigame = false;


    }

    void LateUpdate()
    {
        if (DialogueManager.falando == true || SpawnerManager.nominigame == true || Pause.pausado == true) 
        {
            rb.velocity = rb.velocity * 0f;
            return;
        }
            movimentacao();
        
    }



    public void movimentacao()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playercords = player.transform.position;
        rb.velocity = movimentorb;
        movimentorb = new Vector2(horizontalInput, 0f).normalized * speed;

        if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = true;
        }
        if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = false;
        }

    }



}
