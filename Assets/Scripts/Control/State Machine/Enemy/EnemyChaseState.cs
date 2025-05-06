using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{

    public EnemyChaseState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() 
    { 
        if(stateMachine.PlayScreamer && !stateMachine.AlreadyPlayedScreamer) 
        { 
            stateMachine.SFXHandler.PlayScreamer();
            stateMachine.AlreadyPlayedScreamer = true; 
        }

        stateMachine.Animations.OnLocomotion();
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        FacePlayer(deltaTime);

        MoveToPlayer(deltaTime);

        if(IsInAttackRange())
        {
            stateMachine.SwitchState(new EnemyAttackState(stateMachine));
            return;
        }

        stateMachine.Animations.OnRun();
    }

    public override void Exit() 
    { 
        ResetNavMeshAgent();
    }

    private void ResetNavMeshAgent()
    {
        stateMachine.Agent.ResetPath();
        stateMachine.Agent.velocity = Vector3.zero;
    }

    private void MoveToPlayer(float deltaTime)
    {
        stateMachine.Agent.destination = stateMachine.Player.transform.position;

        Vector3 navMeshVelocity = stateMachine.Agent.desiredVelocity.normalized;
        Vector3 myVelocity = navMeshVelocity * stateMachine.MovementSpeed;

        Move(myVelocity, deltaTime);
    }
}