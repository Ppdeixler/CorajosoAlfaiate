using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPerdeu : MonoBehaviour
{
void Awake()
    {
        Destroy(this.gameObject, 0.3f);
    }
}
