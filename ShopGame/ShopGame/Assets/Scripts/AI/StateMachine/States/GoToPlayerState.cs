using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GoToPlayerState : NPCState
{
    public GoToPlayerState(NPC entity, NPCStatemachine stateMachine, string animBoolName) : base(entity, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

    }

    public override void PhysicsUpdate()    
    {
        base.PhysicsUpdate();
    }
}
