using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{

    private SpawnFogo[] spawners;


    [SerializeField] private GameObject[] locations;

    [SerializeField] private float intervalo;

    private bool banana = false;

    private GameObject player;
    private BoxCollider2D bc2d;
    public static bool nominigame = false;
    void Awake()
    {
        player = GameObject.Find("Player");
        bc2d = player.GetComponent<BoxCollider2D>();

        bc2d.enabled = false;

        spawners = new SpawnFogo[4];

        //StartCoroutine(start());

        nominigame = true;

    }

    void Update()
    {
 
    }

    void Spawn()
    {
        int numeroRandom = Random.Range(0, 4);

        //Debug.Log(numeroRandom);
        spawners[numeroRandom] = locations[numeroRandom].GetComponent<SpawnFogo>();

        spawners[numeroRandom].Spawnar();

        //Debug.Log("oba");

        StopAllCoroutines();    
        
        StartCoroutine(contadora());
          
        


    }

    void truespawn()
    {
        StartCoroutine(contadora());
    }

    public IEnumerator start()
    {
        yield return new WaitForSeconds(0f);

        Spawn();
    }

    IEnumerator contadora()
    {

        yield return new WaitForSeconds(intervalo);
        Spawn();
    }

    public void comecartudo()
    {
        StartCoroutine(start());
    }


}
