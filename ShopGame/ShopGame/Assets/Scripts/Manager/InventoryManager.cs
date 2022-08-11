using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    //Money Amount //Sanity Amount

    //How many items the player has
    public List<BaseItems> Stock;

    private void Awake()
    {
        instance = this;
    }

    public void AddItem(BaseItems item, int amount)
    {
        Stock.Add(item);

        //Debug.Log("2");
        //for (int i = 0; i < Container.Count; i++)
        //{
        //    if(Container[i].Item == item)
        //    {
        //        Container[i].AddAmount(amount);
        //        Debug.Log("2");
        //        break;
        //    }
        //    else
        //    {
        //        Container.Add(new InventorySlot(item, amount));
        //        Debug.Log("1");
        //    }
        //}
    }
}

