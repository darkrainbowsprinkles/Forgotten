using UnityEngine;

[RequireComponent(typeof(Animator), typeof(EnemyAttackHandler))]
public class EnemyAnimations : MonoBehaviour, IEnemyAnimations
{
    private const float AnimationDampTime = 0.1f;

    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");
    private readonly int LocomotionParameterHash = Animator.StringToHash("Speed");
    private readonly int DeadHash = Animator.StringToHash("Enemy_Dead");

    private Animator animator;
    private EnemyAttackHandler attackHandler;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        attackHandler = GetComponent<EnemyAttackHandler>();
    }

    public void OnLocomotion()
    {
        SmoothAnimationTransition(LocomotionHash);
    }

    public void OnIdle()
    {
        SmoothTreeTransition(LocomotionParameterHash, 0f);
    }

    public void OnRun()
    {
        SmoothTreeTransition(LocomotionParameterHash, 1f);
    }

    public void OnRandomAttack()
    {
        int randomAttack = GetRandomAttack();

        SmoothAnimationTransition(randomAttack);
    }

    public void OnDie()
    {
        SmoothAnimationTransition(DeadHash);
    }

    public float GetNormalizedTime(string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0);

        if(!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }

        return 0f; 
    }

    private int GetRandomAttack()
    {
        int randomIndex = Random.Range(0, attackHandler.Attacks.Length);

        attackHandler.SetAttackDamage(randomIndex);

        string attackName = attackHandler.Attacks[randomIndex].AnimationName;

        int attackHash = Animator.StringToHash(attackName);

        return attackHash;
    }

    private void SmoothAnimationTransition(int animationHash)
    {
        animator.PlayInFixedTime(animationHash, 0, AnimationDampTime);
    }

    private void SmoothTreeTransition(int parameterHash, float value)
    {
        animator.SetFloat(parameterHash, value, AnimationDampTime, Time.deltaTime);
    }
}
