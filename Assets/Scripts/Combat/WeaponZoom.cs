using System;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private InputReader inputReader;
    [SerializeField] private float weaponZoomIn = 20f;
    [SerializeField] private float weaponZoomOut = 40f;

    private Camera mainCamera;

    private void OnEnable()
    {
        inputReader.ADSEvent += HandleADS;
        inputReader.ADSCancelEvent += HandleADSCancel;
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnDisable()
    {
        HandleADSCancel();

        inputReader.ADSEvent -= HandleADS;
        inputReader.ADSCancelEvent -= HandleADSCancel;
    }

    private void HandleADS()
    {
        mainCamera.fieldOfView = weaponZoomIn;
    }

    private void HandleADSCancel()
    {
        mainCamera.fieldOfView = weaponZoomOut;
    }
}
