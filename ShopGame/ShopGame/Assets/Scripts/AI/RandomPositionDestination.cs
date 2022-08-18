using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionDestination : MonoBehaviour
{
    public Vector2 Center;
    public Vector2 Size;

    public Vector2 RandomPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector2 GeneratePosition()
    {
        return Center + new Vector2(Random.Range(-Size.x / 2, Size.x / 2),
            Random.Range(-Size.y / 2, Size.y / 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(Center, Size);
    }
}
