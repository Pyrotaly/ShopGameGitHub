using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureListController : ButtonListControl
{
    [SerializeField] private MouseManager mouseManager;

    public BaseBuildTile bbt;

    protected override void TestingPlacingItem(BaseItems itemType)
    {
        RefreshScrollBarMenu();

        //bbt.placeObjectTypeSO = itemType.placedObjectTypeSO;

        mouseManager.gameObject.SetActive(true);
        mouseManager.GetComponent<SpriteRenderer>().sprite = itemType.ItemIcon;
    }
}
