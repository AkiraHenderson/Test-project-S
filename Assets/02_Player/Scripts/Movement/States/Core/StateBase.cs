using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : IState
{
    protected PlayerMovementController owner;


    public StateBase(PlayerMovementController owner)
    {
        this.owner = owner;
    }


    public abstract void Initialize();
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();

}