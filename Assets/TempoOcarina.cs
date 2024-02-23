using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class TempoOcarina : MonoBehaviour
{

    public static bool nominigamewow = false;

    [SerializeField] private GameObject cutscene;

    [SerializeField] private Image image;

    [SerializeField] private float speed;

    [SerializeField] private float plus;

    [SerializeField] private VideoPlayer video;
    [SerializeField] private float videotempo;
    private int ganhar = 0;

    void Update()
    {
        image.fillAmount -= speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            image.fillAmount += plus;
            ganhar++;
        }

        if(ganhar == 30)
        {
            nominigamewow = true;
          SceneManager.LoadScene("Fim");
            ganhar = 100;
        }


    }

    public IEnumerator videocombo()
    {
        cutscene.SetActive(true);

        video.Play();
        yield return new WaitForSeconds(videotempo);

        SceneManager.LoadScene("Menu Inicial");

    }



}
