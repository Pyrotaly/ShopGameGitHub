using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    //Money Amount //Sanity Amount

    //How many items the player has
    public List<InventorySlot> Container = new List<InventorySlot>();

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(BaseItems item, int amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].Item == item)
            {
                Container[i].AddAmount(amount);
                hasItem = true;
                Debug.Log(amount);
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(item, amount));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public BaseItems Item;
    public int Amount;

    public InventorySlot(BaseItems item, int amount)
    {
        item = Item;
        Amount = amount;
    }

    public void AddAmount(int value)
    {
        Amount += value;
    }
}
