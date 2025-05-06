using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private float restoreLightAngle;
    [SerializeField] private float restoreLightIntensity;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerHealth>())
        {
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreLightAngle);
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightIntensity(restoreLightIntensity);

            Destroy(gameObject);
        }
    }
}
