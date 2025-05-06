using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Controller.enabled = false;

        stateMachine.SFXHandler.PlayRandomDeadClip();

        stateMachine.Animations.OnDie();
    }

    public override void Tick(float deltaTime)
    {
        if(stateMachine.Animations.GetNormalizedTime("Die") >= 1f)
        {
            stateMachine.ItemDropper.DropRandomItem(stateMachine.transform);
            MonoBehaviour.Destroy(stateMachine.gameObject);
        }
    }

    public override void Exit() { }
}
