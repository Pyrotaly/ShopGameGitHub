using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{
    private PlacedObjectTypeSO placedObjectTypeSO;
    private PlacedObjectTypeSO.Dir dir;

    public static PlacedObject Create(Vector3 worldPosition, PlacedObjectTypeSO.Dir dir, PlacedObjectTypeSO placedObjectTypeSO)
    {
        Transform placedObjectTransform = Instantiate(placedObjectTypeSO.prefab, worldPosition, 
            Quaternion.Euler(0, 0, placedObjectTypeSO.GetRotationAngle(dir)));  

        PlacedObject placedObject = placedObjectTransform.GetComponent<PlacedObject>();

        placedObject.placedObjectTypeSO = placedObjectTypeSO;
        placedObject.dir = dir;

        return placedObject;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
