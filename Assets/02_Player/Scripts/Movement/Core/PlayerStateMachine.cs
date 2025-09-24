using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public IState CurrentState { get; private set; }

    public IdleState idleState;
    public WalkState walkState;


    private List<IState> states;
    public PlayerStateMachine(PlayerMovementController player)
    {
        states = new List<IState>();
        idleState = AddState<IdleState>(player, states);
        walkState = AddState<WalkState>(player, states);


    }
    public void Initialize(IState startingState)
    {
        for (int i = 0; i < states.Count; i++)
            states[i].Initialize();


        CurrentState = startingState;
        startingState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    private T AddState<T>(PlayerMovementController player, List<IState> states) where T : IState
    {
        var state = (T)Activator.CreateInstance(typeof(T), new object[] { player });
        states.Add(state);
        return state;
    }
}
