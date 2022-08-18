using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class PathFindingFlipper : MonoBehaviour
{
    public AIPath aiPath;

    // Temporary flipper manager
    // This is for 2d platformer, not 2d topdown
    // Script should be placed in NPC GFX, not logic
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
