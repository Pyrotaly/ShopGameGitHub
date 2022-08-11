using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler 
{
    public GameObject testingPrefab;

    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;

    public int x;
    public int y;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void Init(bool isOffset)
    {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($" {x} {y} " );
        

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Instantiate(testingPrefab, new Vector3(x, y), Quaternion.identity);
        }
        else Debug.Log("rightMouseButtonPressed");
    }
}