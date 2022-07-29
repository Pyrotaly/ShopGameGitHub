using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPC : MonoBehaviour
{
    public Animator Anim { get; private set; }
    [HideInInspector] public AIPath aiPath;
    public Transform testTransform;

    protected virtual void Awake()
    {
        Anim = GetComponent<Animator>();
        aiPath = GetComponent<AIPath>();
    }

    protected void Update()
    {
        aiPath.destination = testTransform.position;
    }
}
