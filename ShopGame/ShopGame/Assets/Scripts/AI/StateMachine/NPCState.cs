using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCState 
{
    protected NPCStatemachine stateMachine;
    protected NPC entity;

    protected string animBoolName;

    public NPCState(NPC entity, NPCStatemachine stateMachine, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }
                
    public virtual void Enter()
    {
        entity.Anim.SetBool(animBoolName, true);
        //Debug.Log(animBoolName);
    }

    public virtual void Exit()
    {
        entity.Anim.SetBool(animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {

    }
}
