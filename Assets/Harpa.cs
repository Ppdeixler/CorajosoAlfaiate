using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Harpa : MonoBehaviour
{
    private Inventory inventory;

    

    void Start()
    {
        inventory = GameObject.Find("Inv").GetComponent<Inventory>();
    }



    public IEnumerator harpair()
    {

        yield return new WaitForSeconds(0f);

        SceneManager.LoadScene("Harpa");
    }




    public void comecoharpa()
    {
        StartCoroutine(harpair());
    }


}
