using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; }
    public Vector2 MouseValue { get; private set; }

    public float ScrollWheelValue { get; private set; }

    public event Action JumpEvent;
    public event Action ADSEvent;
    public event Action ADSCancelEvent;
    public event Action FirstSlotEvent;
    public event Action SecondSlotEvent;
    public event Action ThirdSlotEvent;
    public event Action ScrollWheelEvent;
    public event Action PauseEvent;

    public bool IsSprinting;
    public bool IsFiring;

    private Controls controls;

    private void Start()
    {
        controls = new Controls();

        controls.Player.SetCallbacks(this);

        controls.Player.Enable();
    }

    private void OnDestroy()
    {
        controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context) 
    { 
        MouseValue = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        JumpEvent?.Invoke();
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        IsFiring = context.performed;
    }

    public void OnADS(InputAction.CallbackContext context)
    {
        if(context.performed) { ADSEvent?.Invoke(); }
        
        else if(context.canceled) { ADSCancelEvent?.Invoke(); }
    }

    public void OnFirstSlot(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        FirstSlotEvent?.Invoke();
    }

    public void OnSecondSlot(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        SecondSlotEvent?.Invoke();
    }

    public void OnThirdSlot(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        ThirdSlotEvent?.Invoke();
    }

    public void OnMouseWheel(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        ScrollWheelEvent?.Invoke();

        ScrollWheelValue = context.ReadValue<float>();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(!context.performed) { return; }

        PauseEvent?.Invoke();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        IsSprinting = context.performed;
    }
}
