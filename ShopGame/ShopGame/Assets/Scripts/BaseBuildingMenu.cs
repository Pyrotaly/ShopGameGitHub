using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBuildingMenu : MonoBehaviour
{
    public GameObject thing;
    public void AlterActiveObject()
    {
        if (thing.activeInHierarchy == true) thing.SetActive(false);
        else { thing.SetActive(true); }
    }
}
    