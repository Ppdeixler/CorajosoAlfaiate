using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMinigame : MonoBehaviour
{
    [SerializeField] private GameObject minigameocarina;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject minigamemoscas;
    [SerializeField] private GameObject minigamedodge;
    [SerializeField] private GameObject dragao;


    public void ligarocarina()
    {
        if (minigameocarina.activeSelf)
        {
            minigameocarina.SetActive(false);
        }
        else { minigameocarina.SetActive(true); }
    }

    public void ligarmoscas()
    {
        if (minigamemoscas.activeSelf)
        {
            minigamemoscas.SetActive(false);
        } else { minigamemoscas.SetActive(true); }
    }

    public void ligarplayer()
    {
        if (player.activeSelf)
        {
            player.SetActive(false);
        }
        else { player.SetActive(true); }
    }

    public void ligardodge()
    {
        if (minigamedodge.activeSelf)
        {
            minigamedodge.SetActive(false);
        }
        else { minigamedodge.SetActive(true); }
    }

    public void ligardragao()
    {
        if (dragao.activeSelf)
        {
            dragao.SetActive(false);
        }
        else { dragao.SetActive(true); }
    }

}
