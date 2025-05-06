using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    [field: SerializeField] public Attack[] Attacks { get; private set; }

    [SerializeField] private AttackDamage attackDamage;
    [SerializeField] private GameObject weapon;

    public void EnableWeapon()
    {
        weapon.SetActive(true);
    }

    public void DisableWeapon()
    {
        weapon.SetActive(false);
    }

    public void SetAttackDamage(int index)
    {
        attackDamage.SetAttack(Attacks[index].Damage);
    }
}
