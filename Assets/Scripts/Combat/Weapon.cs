using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AmmoType ammoType;
    [SerializeField] private bool isAutomatic = false;
    [SerializeField] private AudioClip weaponShotClip;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject muzzleFlashVFX;
    [SerializeField] private GameObject hitVFX;
    [SerializeField] private Transform muzzle;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Ammo ammoSlot;
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private float shootDistance;
    [SerializeField] private float shootDamage;
    [SerializeField] private float shootDelay;

    public event Action<AmmoType> onWeaponShot;

    private Transform mainCameraTransform;
    private bool canShoot = true;
    private bool wasFiringLastFrame = false;

    private void OnEnable()
    {
        canShoot = true;
        wasFiringLastFrame = false;
        playerHealth.onPlayerDead += HandePlayerDead;
    }

    private void Start()
    {
        mainCameraTransform = Camera.main.transform;
    }

    private void Update()
    {
        DisplayAmmo();

        bool isFiring = inputReader.IsFiring;

        if (isAutomatic)
        {
            if (isFiring)
            {
                StartCoroutine(HandleFire());
            }
        }
        else
        {
            if (isFiring && !wasFiringLastFrame)
            {
                StartCoroutine(HandleFire());
            }
        }

        wasFiringLastFrame = isFiring;
    }

    private void OnDisable()
    {
        playerHealth.onPlayerDead -= HandePlayerDead;
    }

    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetAmmo(ammoType);
        ammoText.text = $"Ammo: {currentAmmo}";
    }

    private IEnumerator HandleFire()
    {
        if (!canShoot) { yield break; }

        if (ammoSlot.GetAmmo(ammoType) <= 0) { yield break; }

        canShoot = false;

        onWeaponShot?.Invoke(ammoType);

        HandleRayCastHit();

        ammoSlot.ReduceCurrentAmmo(ammoType);

        yield return new WaitForSeconds(shootDelay);

        canShoot = true;
    }

    private void PlayMuzzleFlashVFX()
    {
        Instantiate(muzzleFlashVFX, muzzle);
    }

    private void PlayHitVFX(RaycastHit hit)
    {
        Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
    }

    private void HandleRayCastHit()
    {
        RaycastHit hit = GetRaycastHit();

        PlayMuzzleFlashVFX();

        if (hit.transform == null) { return; }

        if (hit.transform.GetComponent<PlayerStateMachine>()) { return; }

        if (hit.transform.TryGetComponent(out EnemyHealth health))
        {
            health.TakeDamage(shootDamage);
        }

        PlayHitVFX(hit);
    }

    private RaycastHit GetRaycastHit()
    {
        RaycastHit hit;

        Vector3 origin = mainCameraTransform.position;
        Vector3 direction = mainCameraTransform.forward;
        float maxDistance = shootDistance;

        Physics.Raycast(origin, direction, out hit, maxDistance);

        return hit;
    }

    private void HandePlayerDead()
    {
        canShoot = false;
    }
}
