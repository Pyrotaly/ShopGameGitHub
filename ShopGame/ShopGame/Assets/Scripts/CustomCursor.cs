using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class CustomCursor : MonoBehaviour
{
    //private void Start()
    //{
    //    Cursor.visible = false;
    //}

    [SerializeField] private float zPosition;

    public Camera mainCam;
    private Vector3 worldPos;

    Vector3 testPos;


    private void Update()
    {
        worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        transform.position = new Vector3(worldPos.x, worldPos.y, zPosition);
        //Get sprite of the item selected
    }
}
    