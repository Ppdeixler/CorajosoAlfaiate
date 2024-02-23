using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFogo : MonoBehaviour
{

    [SerializeField] private GameObject prefabInimigo;

    private GameObject spawner;

    private SpriteRenderer sprite;

    void Awake()
    {
        spawner = this.gameObject;

        sprite = GetComponent<SpriteRenderer>();

    }


    void Update()
    {

    }


    public void Spawnar()
    {

        Vector2 cantoInferiorEsquerdo = new Vector2(spawner.transform.position.x - sprite.bounds.extents.x, spawner.transform.position.y - sprite.bounds.extents.y);
        Vector2 cantoSuperiorEsquerdo = new Vector2(spawner.transform.position.x + sprite.bounds.extents.x, spawner.transform.position.y + sprite.bounds.extents.y);

        Vector2 randomLocation = new Vector2(Random.Range(cantoInferiorEsquerdo.x, cantoSuperiorEsquerdo.x), Random.Range(cantoInferiorEsquerdo.y, cantoSuperiorEsquerdo.y));

        Instantiate(prefabInimigo, randomLocation, Quaternion.identity);

    }


}
