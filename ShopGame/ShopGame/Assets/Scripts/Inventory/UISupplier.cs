using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISupplier : MonoBehaviour
{
    private Transform Sellable;
    private Transform container1;
    private Transform shopItemTemplate1;

    private Transform Function;
    private Transform container2;
    private Transform shopItemTemplate2;

    [SerializeField] private float shopItemHeight;

    public List<BaseItems> ItemList;

    private void Awake()
    {
        //Menu1   
        Sellable = transform.Find("Sellable");
        container1 = Sellable.Find("container1");
        shopItemTemplate1 = container1.Find("ShopItemTemplate1");

        //Menu2
        Function = transform.Find("Function");
        container2 = Function.Find("container2");
        shopItemTemplate2 = container2.Find("ShopItemTemplate2");

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

    //This is for only one menu
    private void CreateItemButton(Sprite itemSprite, string itemName, float itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate1, container1);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        //float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("itemIcon").GetComponent<Image>().sprite = itemSprite;
        shopItemTransform.Find("itemName").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("itemPrice").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
    }

    public void RightClickTemp()
    {
        Sellable.gameObject.SetActive(false);
        Function.gameObject.SetActive(true);
    }

    public void LeftClickTemp()
    {
        Sellable.gameObject.SetActive(true);
        Function.gameObject.SetActive(false);
    }
}
