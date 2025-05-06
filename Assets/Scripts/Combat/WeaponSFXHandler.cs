using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class WeaponSFXHandler : MonoBehaviour
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private Weapon[] weapons;

    [Header("Ammo Pickup Clips")]
    [SerializeField] private AudioClip lightPistolAmmo;
    [SerializeField] private AudioClip heavyPistolAmmo;
    [SerializeField] private AudioClip rifleAmmo;

    [Header("Weapon Shot Clips")]
    [SerializeField] private AudioClip lightPistolShot;
    [SerializeField] private AudioClip heavyPistolShot;
    [SerializeField] private AudioClip rifleShot;

    private AudioSource audioSource;

    private void OnEnable()
    {
        ammo.onIncreaseAmmo += OnAmmoPickup;

        foreach(Weapon weapon in weapons)
        {
            weapon.onWeaponShot += OnWeaponShot;
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        ammo.onIncreaseAmmo -= OnAmmoPickup;

        foreach(Weapon weapon in weapons)
        {
            weapon.onWeaponShot -= OnWeaponShot;
        }
    }

    public void OnAmmoPickup(AmmoType ammoType)
    {
        switch(ammoType)
        {
            case AmmoType.LightPistol:
                audioSource.PlayOneShot(lightPistolAmmo);
                break;
            case AmmoType.HeavyPistol:
                audioSource.PlayOneShot(heavyPistolAmmo);
                break;
            case AmmoType.Rifle:
                audioSource.PlayOneShot(rifleAmmo);
                break;
        }
    }

    public void OnWeaponShot(AmmoType ammoType)
    {
        switch(ammoType)
        {
            case AmmoType.LightPistol:
                audioSource.PlayOneShot(lightPistolShot);
                break;
            case AmmoType.HeavyPistol:
                audioSource.PlayOneShot(heavyPistolShot);
                break;
            case AmmoType.Rifle:
                audioSource.PlayOneShot(rifleShot);
                break;
        }
    }    
}
