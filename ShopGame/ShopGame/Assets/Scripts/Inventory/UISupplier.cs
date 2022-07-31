using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISupplier : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;

    [SerializeField] private float shopItemHeight;

    public List<BaseItems> ItemList;

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        //shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        //Displays Items on Canvas 
        for (int i = 0; i < ItemList.Count; i++) //There should be the same length for all data types
        {
            CreateItemButton(ItemList[i].ItemIcon, ItemList[i].ItemName, ItemList[i].ItemPrice, i);
        }
    }

    private void CreateItemButton(Sprite itemSprite, string itemName, float itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        //float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemIcon").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("itemPrice").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
    }
}
