using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureListController : ButtonListControl
{
    protected override void TestingPlacingItem(BaseItems itemType)
    {
        RefreshScrollBarMenu();
    }
}
