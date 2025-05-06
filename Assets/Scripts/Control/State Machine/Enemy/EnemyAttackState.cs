using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    public EnemyAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() 
    { 
        stateMachine.SFXHandler.PlayRandomAttackClip();
        stateMachine.Animations.OnRandomAttack();
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        FacePlayer(deltaTime);
        
        if(stateMachine.Animations.GetNormalizedTime("Attack") >= 1f)
        {
            stateMachine.SwitchState(new EnemyChaseState(stateMachine));
        }
    }

    public override void Exit() { }
}
