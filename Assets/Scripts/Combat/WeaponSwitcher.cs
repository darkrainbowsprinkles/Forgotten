using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private int currentWeapon = 0;

    private void OnEnable()
    {
        inputReader.FirstSlotEvent += HandleFirstSlot;
        inputReader.SecondSlotEvent += HandleSecondSlot;
        inputReader.ThirdSlotEvent += HandleThirdSlot;
        inputReader.ScrollWheelEvent += HandleScrollWheel;

        playerHealth.onPlayerDead += HandlePlayerDead;
    }

    private void Start()
    {
        SetWeaponActive();
    }

    private void OnDisable()
    {
        inputReader.FirstSlotEvent -= HandleFirstSlot;
        inputReader.SecondSlotEvent -= HandleSecondSlot;
        inputReader.ThirdSlotEvent -= HandleThirdSlot;
        inputReader.ScrollWheelEvent -= HandleScrollWheel;

        playerHealth.onPlayerDead -= HandlePlayerDead;  
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if(weaponIndex == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false); 
            }

            weaponIndex++;
        }
    }

    private void HandleScrollWheel()
    {
        if(inputReader.ScrollWheelValue > 0)
        {
            if(currentWeapon >= (transform.childCount - 1))
            {
                currentWeapon = 0;
                SetWeaponActive();
            }
            else
            {
                currentWeapon ++;
                SetWeaponActive();
            }
        }
        else if(inputReader.ScrollWheelValue < 0)
        {
            if(currentWeapon <= 0)
            {
                currentWeapon = transform.childCount - 1;
                SetWeaponActive();
            }
            else
            {
                currentWeapon --;
                SetWeaponActive();
            }
        }
    }

    private void HandleFirstSlot()
    {
        currentWeapon = 0;

        SetWeaponActive();
    }  

    private void HandleSecondSlot()
    {
        currentWeapon = 1;

        SetWeaponActive();
    }

    private void HandleThirdSlot()
    {
        currentWeapon = 2;

        SetWeaponActive();
    } 

    private void HandlePlayerDead()
    {
        inputReader.FirstSlotEvent -= HandleFirstSlot;
        inputReader.SecondSlotEvent -= HandleSecondSlot;
        inputReader.ThirdSlotEvent -= HandleThirdSlot;
        inputReader.ScrollWheelEvent -= HandleScrollWheel;
    }
}
