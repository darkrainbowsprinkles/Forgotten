using System;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType;
    [SerializeField] private int ammoAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Ammo>(out Ammo ammo))
        {
            ammo.IncreaseCurrentAmmo(ammoType, ammoAmount);

            Destroy(gameObject);
        }
    }
}
