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

    private void Awake()
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        //shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        CreateItemButton(0);
        CreateItemButton(1);
    }

    private void CreateItemButton(int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();
        //float shopItemHeight = 30f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        //When I find a way to get refernce to item names prices and such, can set them when adding to list
        //shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemName);  
        //shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(priceName.ToString());  
    }
}
