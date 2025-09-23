using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateBase : IState
{
    protected PlayerMovementController player;


    public PlayerStateBase(PlayerMovementController player)
    {
        this.player = player;
    }


    public abstract void Initialize();
    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();

}