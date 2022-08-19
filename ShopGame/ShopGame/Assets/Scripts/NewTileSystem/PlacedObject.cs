using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedObject : MonoBehaviour
{
    public static PlacedObject Create(Vector3 worldPosition, //Vector2Int origin,
        PlacedObjectTypeSO.Dir dir, PlacedObjectTypeSO placedObjectTypeSO)
    {
        Transform placedObjectTransform = Instantiate(placedObjectTypeSO.prefab, worldPosition, 
            Quaternion.Euler(0, 0, placedObjectTypeSO.GetRotationAngle(dir)));  

        PlacedObject placedObject = placedObjectTransform.GetComponent<PlacedObject>();

        placedObject.placedObjectTypeSO = placedObjectTypeSO;
        //placedObject.origin = origin;
        placedObject.dir = dir;

        return placedObject;
    }

    private PlacedObjectTypeSO placedObjectTypeSO;  
    private Vector2Int origin;  
    private PlacedObjectTypeSO.Dir dir;

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
