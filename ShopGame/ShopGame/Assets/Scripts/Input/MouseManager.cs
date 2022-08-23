using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Camera mainCam;
    private Vector3 worldPos;

    Vector3 testPos;

    [SerializeField] private float zPosition;

    public Action OnMouseHover, OnMouseDown, OnMouseUp;

    void Update()
    {
        worldPos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //testPos = new Vector2(Mathf.Round(worldPos.x), Mathf.Round(worldPos.y));    //Used for tile selection
        transform.position = new Vector3(worldPos.x, worldPos.y, zPosition);          //Exact mouse position, used for changing cursor icon
    }

    //Hovering over something
    public void OnPointerEnter(PointerEventData eventData) 
    {
        OnMouseHover?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnMouseUp?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnMouseDown?.Invoke();
    }
}
