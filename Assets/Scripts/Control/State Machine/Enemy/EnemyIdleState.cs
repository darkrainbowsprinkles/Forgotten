using System;
using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    public EnemyIdleState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() 
    { 
        stateMachine.EnemyHealth.onDamageTaken += HandleDamageTaken;

        stateMachine.Animations.OnLocomotion();
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if(IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyChaseState(stateMachine));
            return;
        }
        
        stateMachine.Animations.OnIdle();
    }

    public override void Exit() 
    { 
        stateMachine.EnemyHealth.onDamageTaken -= HandleDamageTaken;
    }

    private void HandleDamageTaken()
    {
        stateMachine.SwitchState(new EnemyChaseState(stateMachine));
    }
}
