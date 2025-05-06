using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healthAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            if(playerHealth.HasMaxHealth) { return; }

            playerHealth.Heal(healthAmount);

            Destroy(gameObject);
        }
    }
}