using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate; //prefab button to spawn

    private List<int> intList; //This will be player inventory list later
                               //Well, for player inventory, maybe make it a generic list

    [SerializeField] private Transform newButtonTemplate;

    [SerializeField] private CustomCursor customCursor;

    private List<BaseItems> ScrollBarList;         //I am duplicating list when I just want to refer to list but less keystrokes!!!
    private Action testAction;

    private void Start()
    {
        RefreshScrollBarMenu();
    }

    private void RefreshScrollBarMenu()
    {
        ScrollBarList = InventoryManager.instance.CheckItem;  //I am duplicating list when I just want to refer to list but less keystrokes!!!

        for (int i = 0; i < ScrollBarList.Count; i++) //There should be the same length for all data types
        {
            CreateItemButton(ScrollBarList[i], ScrollBarList[i].ItemIcon, ScrollBarList[i].ItemName, ScrollBarList[i].ItemPrice, i);
        }

        Debug.Log(ScrollBarList.Count);
    }

    //This is for only one menu, creates list of buttons for items
    private void CreateItemButton(BaseItems item, Sprite itemSprite, string itemName, float itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(newButtonTemplate);
        shopItemTransform.SetParent(buttonTemplate.transform.parent, false);

        shopItemTransform.Find("itemIcon").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("itemPrice").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.GetComponent<Button>().onClick.AddListener(delegate { TestingPlacingItem(item); });
    }

    private void TestingPlacingItem(BaseItems itemType)
    {
        //This makes cursor icon into the item player selected, not sure if it is smart to handle it here
        customCursor.gameObject.SetActive(true);
        customCursor.GetComponent<SpriteRenderer>().sprite = itemType.ItemIcon;
        //Cursor.visible = false;
    }
}

