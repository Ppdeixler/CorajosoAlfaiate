using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigAudio : MonoBehaviour
{
    private AudioManager manageraudio;

    [SerializeField] private string nomeaudio;

    void Start()
    {
        manageraudio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }


    public void trig()
    {
        manageraudio.Play(nomeaudio);
    }




}
