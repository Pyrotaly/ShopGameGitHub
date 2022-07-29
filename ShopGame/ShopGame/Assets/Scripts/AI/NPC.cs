using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator Anim { get; private set; }
    public Transform testTransform;

    protected virtual void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    protected void Update()
    {
    }
}
