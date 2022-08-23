using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    //Sanity Amount

    public int MoneyAmount;

    //How many items the player has
    public List<BaseItems> CheckItem; 
    public List<InventorySlot> Stock;

    //Right now, everytime altering item list, refresh scrollbar screen
    public Action OnAlteringItemList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        MoneyAmount = 10000;  //If I load game, does this keep setting money amount?
    }

    //Adding item to play list, through stocker or picking up items
    public void AddItem(BaseItems item, int amount)
    {
        if (!CheckItem.Contains(item))
        {
            CheckItem.Add(item);
            Stock.Add(new InventorySlot(item, amount));
        }
        else
        {
            for (int i = 0; i < Stock.Count; i++)
            {
                if (Stock[i].item == item)
                {
                    Stock[i].IncreaseValue();
                    Debug.Log($"{item} stock = {Stock[i].amount}"); //Should say 2 at first
                    break;
                }
            }
        }

        OnAlteringItemList?.Invoke();
    }

    public void RemoveItem(BaseItems item, int amount)
    {
        if (!CheckItem.Contains(item))
        {
            Debug.LogError("item not there need to worry");
        }
        else
        {
            for (int i = 0; i < Stock.Count; i++)
            {
                if (Stock[i].item == item)
                {
                    if (Stock[i].amount > 0)
                    {
                        Stock[i].DecreaseValue();
                        Debug.Log($"{item} stock = {Stock[i].amount}");
                    }
                    else
                    {
                        Stock[i].amount = 0;
                        CheckItem.Remove(item);
                    }
                    break;
                }
            }
        }

        OnAlteringItemList?.Invoke();
    }

    //Increase or decrease player money here
    public void AdjustMoney(int amount) 
    {
        MoneyAmount += amount;
    }
}

[System.Serializable]
public class InventorySlot
{
    public BaseItems item;
    public int amount;

    public InventorySlot(BaseItems item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public void IncreaseValue()
    {
        amount++;
    }

    public void DecreaseValue()
    {
        amount--;
    }
}
