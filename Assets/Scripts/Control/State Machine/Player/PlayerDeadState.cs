using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    public PlayerDeadState(PlayerStateMachine stateMachine) : base(stateMachine) { } 

    public override void Enter()
    { 
        stateMachine.Controller.enabled = false;

        Time.timeScale = 0.2f;
    }

    public override void Tick(float deltaTime) { }

    public override void Exit() { }
}
