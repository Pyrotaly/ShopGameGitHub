using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    //private void Start()
    //{
    //    Cursor.visible = false;
    //}


    private void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
        //Get sprite of the item selected
    }
}
    