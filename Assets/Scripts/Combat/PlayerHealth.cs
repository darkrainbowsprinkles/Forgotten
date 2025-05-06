using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{
    [field: SerializeField] public float MaxHealth { get; private set; }

    public float CurrentHealth { get; private set; }

    public event Action onHealthChange;
    public event Action onPlayerHeal;
    public event Action onPlayerDead;

    private bool IsDead => CurrentHealth <= 0;
    public bool HasMaxHealth => CurrentHealth >= MaxHealth;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }


    public void TakeDamage(float amount)
    {
        if(IsDead) { return; }

        CurrentHealth = Mathf.Max(CurrentHealth - amount, 0f);

        onHealthChange?.Invoke();

        if(IsDead) { Die(); }
    }

    public void Heal(float amount)
    {
        if(IsDead) { return; }
        if(HasMaxHealth) { return;}

        CurrentHealth += amount;

        onHealthChange?.Invoke();
        onPlayerHeal?.Invoke();
    }

    private void Die()
    {
        onPlayerDead?.Invoke();
    }
}
