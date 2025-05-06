using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealth
{
    [SerializeField] private float maxHealth;

    private float currentHealth;

    private bool IsDead => currentHealth <= 0;

    public event Action onDamageTaken;
    public event Action onEnemyDead;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if(IsDead) { return; }

        currentHealth = Mathf.Max(currentHealth - amount, 0f);

        onDamageTaken?.Invoke();

        if(IsDead) { Die(); }
    }

    private void Die()
    {
        onEnemyDead?.Invoke();
    }

}
