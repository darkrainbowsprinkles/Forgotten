 using UnityEngine;

[RequireComponent(typeof(InputReader), typeof(CharacterController), typeof(ForceReceiver))]
public class PlayerStateMachine : StateMachine
{
    [field: Header("References")]
    [field: SerializeField] public InputReader InputReader { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public PlayerHealth PlayerHealth { get; private set; }

    [field: Header("Values")]
    [field: SerializeField] [field: Range(0.1f, 100f)] private float freeMouseSensitivity = 10f;
    [field: SerializeField] [field: Range(0.1f, 100f)] private float adsMouseSensitivity = 5f;

    public float FreeMouseSensitivity
    {
        get => freeMouseSensitivity;
        set
        {
            freeMouseSensitivity = value;
            if (!isADS) MouseSensitivity = value;
        }
    }

    public float ADSMouseSensitivity
    {
        get => adsMouseSensitivity;
        set
        {
            adsMouseSensitivity = value;
            if (isADS) MouseSensitivity = value;
        }
    }

    private bool isADS = false;

    [field: SerializeField] [field: Range(0.1f, 10f)] public float JumpForce { get; private set; }
    [field: SerializeField] [field: Range(0.1f, 20f)] public float FreeMovementSpeed { get; private set; }

    public float MouseSensitivity { get; private set; }

    public Transform MainCameraTransform { get; private set; }

    private void OnEnable()
    {
        PlayerHealth.onPlayerDead += HandleDead;
        InputReader.ADSEvent += HandleADS;
        InputReader.ADSCancelEvent += HandleADSCancel;
    }

    private void Start()
    {
        MouseSensitivity = FreeMouseSensitivity;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerFreeLookState(this));
    }

    private void OnDisable()
    {
        PlayerHealth.onPlayerDead -= HandleDead;
        InputReader.ADSEvent -= HandleADS;
        InputReader.ADSCancelEvent -= HandleADSCancel;
    }

    private void HandleADS()
    {
        isADS = true;
        MouseSensitivity = ADSMouseSensitivity;
    }

    private void HandleADSCancel()
    {
        isADS = false;
        MouseSensitivity = FreeMouseSensitivity;
    }

    private void HandleDead()
    {
        SwitchState(new PlayerDeadState(this));
    }
}
