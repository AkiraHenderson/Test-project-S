using UnityEngine;

public class IdleState : StateBase
{

    public IdleState(PlayerMovementController owner) : base(owner)
    {

    }
    public override void Initialize()
    {
      
    }
    public override void Enter()
    {
       
    }
    public override void Update()
    {
        if (owner.inputHandler.MoveInput != 0)
            owner.stateMachine.TransitionTo(owner.stateMachine.walkState);

    }
    public override void Exit()
    {

    }
}
