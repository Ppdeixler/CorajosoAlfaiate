using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseMosca : MonoBehaviour
{

    private Vector3 position;

    private Vector3 mouseP;

    private int ganhar = 0;


    void Update()
    {
        mouseP = Input.mousePosition;

      
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(mouseP).x, Camera.main.ScreenToWorldPoint(mouseP).y, 0f);

        if(ganhar == 7)
        {
            SceneManager.LoadScene("Nível1_Casa");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Mosca")
        {
            Destroy(other.gameObject);
            ganhar++;
        }
    }

}
