using UnityEngine;

public class WalkState : StateBase
{

    public WalkState(PlayerMovementController owner) : base(owner)
    {

    }
    public override void Initialize()
    {

    }
    public override void Enter()
    {
        owner.animationController.Move(true);
    }
    public override void Update()
    {   

        if (owner.inputHandler.MoveInput == 0)
        {
            owner.stateMachine.TransitionTo(owner.stateMachine.idleState);
        }
    }
    public override void Exit()
    {
        owner.animationController.Move(false);
    }
}
