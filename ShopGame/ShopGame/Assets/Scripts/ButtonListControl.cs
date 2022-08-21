using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListControl : MonoBehaviour
{
    [SerializeField] private GameObject buttonTemplate; //prefab button to spawn

    private List<int> intList; //This will be player inventory list later
                               //Well, for player inventory, maybe make it a generic list

    private void Start()
    {
        for (int i = 0; i <= 20; i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText("Button #" + i);
            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
}
