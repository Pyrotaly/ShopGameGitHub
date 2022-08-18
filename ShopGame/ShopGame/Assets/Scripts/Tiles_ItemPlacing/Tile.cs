using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler 
{
    [SerializeField] private Transform testTransform;

    [SerializeField] private PlacedObjectTypeSO placeObjectTypeSO;
    private PlacedObjectTypeSO.Dir dir = PlacedObjectTypeSO.Dir.Down;

    private Transform thisTransform;

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

    public bool CanBuild() { return thisTransform == null; }

    public void ClearTransform() { thisTransform = null; }

    public void SetTransform(Transform transform) { thisTransform = transform; }

    #region MouseLogic
    public void OnPointerEnter(PointerEventData eventData)
    {
        highlight.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.SetActive(false);
    }

    //Currently the only time player would click on a tile is during base building to place items down, or rotate
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log($" {x} {y} " );
                                                                                    //Where this object is placed       //Direction of object
        List<Vector2Int> gridPositionList = placeObjectTypeSO.GetGridPositionList(new Vector2Int(this.x, this.y), dir);

        //Temp placing thing on tile
        if (eventData.button == PointerEventData.InputButton.Left)
        {

            //Checks if any space when placing a new object is already occupied and then won't let player place
            bool canBuild = true;
            foreach (Vector2Int gridPosition in gridPositionList)
            {
                if (!GridManager.instance.GetTileAtPosition(gridPosition).CanBuild())
                {
                    canBuild = false;
                    break;
                }
            }

            if (canBuild)
            {
                Transform builtTransform =
                    Instantiate(
                        placeObjectTypeSO.prefab,
                        new Vector3(x, y),
                        Quaternion.Euler(0, 0, placeObjectTypeSO.GetRotationAngle(dir))
                    );
                foreach (Vector2Int gridPosition in gridPositionList)
                {
                    GridManager.instance.GetTileAtPosition(gridPosition).SetTransform(builtTransform);
                }
            }
            else
            {
                Debug.Log("cannot build here");
            }   
        }

        //Right mouse button rotates selected object, NOT IDEAL RN
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("hi");
            dir = PlacedObjectTypeSO.GetNextDir(dir);
        }


    }
    #endregion
}