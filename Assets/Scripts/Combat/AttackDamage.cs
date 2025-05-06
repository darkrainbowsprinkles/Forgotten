using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    
    private List<Collider> alreadyCollidedWith = new List<Collider>();

    private float damage;

    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == myCollider) { return; }

        if(alreadyCollidedWith.Contains(other)) { return; }

        alreadyCollidedWith.Add(other);

        if(other.TryGetComponent<PlayerHealth>(out PlayerHealth health))
        {
            health.TakeDamage(damage);
        }
    }

    public void SetAttack(float damage)
    {
        this.damage = damage;
    }
}
