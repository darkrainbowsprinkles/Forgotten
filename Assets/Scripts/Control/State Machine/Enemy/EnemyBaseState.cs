using UnityEngine;

public abstract class EnemyBaseState : State
{   
    protected EnemyStateMachine stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    
    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        Vector3 gravity = stateMachine.ForceReceiver.Movement;
        
        stateMachine.Controller.Move((motion + gravity) * deltaTime);

        stateMachine.Agent.velocity = stateMachine.Controller.velocity;
    }

    protected bool IsInChaseRange()
    {
        Vector3 myPosition = stateMachine.transform.position;
        Vector3 playerPosition = stateMachine.Player.transform.position;

        float distanceToPlayerSqr = (myPosition - playerPosition).sqrMagnitude;
        float chaseRangeSqr = stateMachine.ChaseRange * stateMachine.ChaseRange;

        return distanceToPlayerSqr <= chaseRangeSqr;
    } 

    protected bool IsInAttackRange()
    {
        Vector3 myPosition = stateMachine.transform.position;
        Vector3 playerPosition = stateMachine.Player.transform.position;

        float distanceToPlayerSqr = (myPosition - playerPosition).sqrMagnitude;
        float attackRangeSqr = stateMachine.AttackRange * stateMachine.AttackRange;

        return distanceToPlayerSqr <= attackRangeSqr;
    }   
    
    protected void FacePlayer(float deltaTime)
    {
        if(stateMachine.Player == null) { return; }

        Vector3 direction = (stateMachine.Player.transform.position - stateMachine.transform.position).normalized;
        direction.y = 0f;

        Quaternion currentRotation = stateMachine.transform.rotation;

        Quaternion lookRotation = Quaternion.LookRotation(direction);

        float rotationSpeed = stateMachine.RotationSpeed;

        stateMachine.transform.rotation = Quaternion.Slerp(currentRotation, lookRotation, rotationSpeed * deltaTime);
    }
}
