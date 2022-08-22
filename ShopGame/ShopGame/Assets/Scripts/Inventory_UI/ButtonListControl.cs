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

    private List<BaseItems> SellingItemList;
    private Action testAction;

    private void Start()
    {
        SellingItemList = InventoryManager.instance.CheckItem;

        Debug.Log(SellingItemList.Count);

        RefreshScrollBarMenu();
    }

    private void RefreshScrollBarMenu()
    {
        for (int i = 0; i < SellingItemList.Count; i++) //There should be the same length for all data types
        {
            CreateItemButton(SellingItemList[i], SellingItemList[i].ItemIcon, SellingItemList[i].ItemName, SellingItemList[i].ItemPrice, i);
            
        }
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
        //shopItemTransform.GetComponent<Button>().onClick.AddListener(delegate { testAction(); });
    }

    private void TestingPlacingItem(BaseItems itemType)
    {
        //This makes cursor icon into the item player selected, not sure if it is smart to handle it here
        customCursor.gameObject.SetActive(true);
        customCursor.GetComponent<SpriteRenderer>().sprite = itemType.ItemIcon;
        Debug.Log("HELLO");
        //Cursor.visible = false;
    }
}

