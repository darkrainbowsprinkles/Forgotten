using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private float xRotation = 0f;
    private float xRotationLimit = 90f;

    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter() 
    { 
        stateMachine.InputReader.JumpEvent += HandleJump;
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        Move(movement * stateMachine.FreeMovementSpeed, deltaTime);

        MouseRotation(stateMachine.InputReader.MouseValue, deltaTime);
    }

    public override void Exit() 
    { 
        stateMachine.InputReader.JumpEvent -= HandleJump;
    }

    private void HandleJump()
    {
        stateMachine.ForceReceiver.Jump(stateMachine.JumpForce);
    }
    
    private Vector3 CalculateMovement()
    {
        Vector3 xMovement = stateMachine.InputReader.MovementValue.x * stateMachine.transform.right;
        Vector3 zMovement = stateMachine.InputReader.MovementValue.y * stateMachine.transform.forward;

        return xMovement + zMovement;
    }

    private void MouseRotation(Vector2 mouseMovement, float deltaTime)
    {
        if(mouseMovement == Vector2.zero) { return; }

        float mouseX = mouseMovement.x * stateMachine.MouseSensitivity * deltaTime;
        float mouseY = mouseMovement.y * stateMachine.MouseSensitivity * deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xRotationLimit, xRotationLimit);

        stateMachine.transform.Rotate(Vector3.up * mouseX);
        stateMachine.MainCameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}