using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorClick;

    private Vector2 cursorHotspot;

    private Vector2 mousePosition;

    [SerializeField] private ParticleSystem pSystem;


    void Update()
    {
        setarCursor();

    }





    void setarCursor()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        if (hit.collider == null)
        {
            cursorHotspot = new Vector2(cursorNormal.width / 3, cursorNormal.height / 3);
            Cursor.SetCursor(cursorNormal, cursorHotspot, CursorMode.Auto);
            pSystem.Pause();
            pSystem.Clear();
            return;
        }
        if (hit.collider.gameObject == null) { return; }

        if(hit.collider.gameObject.TryGetComponent<ItemNome>(out ItemNome nomedoitem))
        {
            cursorHotspot = new Vector2(cursorClick.width / 3, cursorClick.height / 3);
            Cursor.SetCursor(cursorClick, cursorHotspot, CursorMode.Auto);
            pSystem.Play();
        }
        else
        {
            cursorHotspot = new Vector2(cursorNormal.width / 3, cursorNormal.height / 3);
            Cursor.SetCursor(cursorNormal, cursorHotspot, CursorMode.Auto);
            pSystem.Pause();
            pSystem.Clear();
        }

    }


}
