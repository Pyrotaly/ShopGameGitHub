using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : NPCState
{
    public PauseState(NPC entity, NPCStatemachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }
}
