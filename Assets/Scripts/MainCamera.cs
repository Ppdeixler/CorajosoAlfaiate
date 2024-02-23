using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    private Vector3 cameravector;
    [SerializeField] private GameObject player;


    void LateUpdate()
    {
        cameravector = player.transform.position;
        this.transform.position = new Vector3(cameravector.x + offset.x, cameravector.y + offset.y, cameravector.z + offset.z);
    }



}
