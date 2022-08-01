using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatemachine 
{
    public NPCState CurrentState { get; private set; }

    public void Initialize(NPCState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(NPCState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
