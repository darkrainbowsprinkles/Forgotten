using UnityEngine;

public interface IEnemyAnimations 
{
    void OnLocomotion();
    void OnIdle();
    void OnRun();
    void OnRandomAttack();
    void OnDie();
}
