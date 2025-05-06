using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [field: Header("References")]
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public EnemyHealth EnemyHealth { get; private set; }
    [field: SerializeField] public EnemyAnimations Animations { get; private set; }
    [field: SerializeField] public ItemDropper ItemDropper { get; private set; }
    [field: SerializeField] public EnemySFXHandler SFXHandler { get; private set; }

    [field: Header("Values")]
    [field: SerializeField] [field: Range(0.1f, 20f)] public float MovementSpeed { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 50f)] public float ChaseRange { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] public float AttackRange { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] public float RotationSpeed { get; private set; }
    [field: SerializeField] public bool PlayScreamer { get; private set; } = false;

    public bool AlreadyPlayedScreamer { get; set; } = false;
    public PlayerHealth Player { get; private set; }

    private void OnEnable()
    {
        EnemyHealth.onEnemyDead += HandleDeath;
    }

    private void Start()
    {
        Player = FindObjectOfType<PlayerHealth>();

        Agent.updatePosition = false;
        Agent.updateRotation = false;

        SwitchState(new EnemyIdleState(this));
    }

    private void OnDisable()
    {
        EnemyHealth.onEnemyDead -= HandleDeath;
    }

    private void HandleDeath()
    {
        SwitchState(new EnemyDeadState(this));
    }

    private void OnDrawGizmosSelected()
    {
        // Chase Range Gizmos
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ChaseRange);

        // Attack Range Gizmos
        Gizmos.color = Color.red;
        Vector3 myPosition = transform.position;
        float gizmosCenterOffset = 1.3f;

        myPosition.y = myPosition.y + gizmosCenterOffset;

        Gizmos.DrawWireSphere(myPosition, AttackRange);
    }

}
