using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputManager", menuName = "InputManager")]

public class InputManager : ScriptableObject, InputSystem.IPlayerActions
{
    private InputSystem _inputSystem;

    public event Action<Vector2> OnMoved;
    public event Action<Vector2> OnLooked;
    public event Action OnJumped;

    public Vector2 Direction => _inputSystem.Player.Move.ReadValue<Vector2>();
    public Vector2 LookDelta => _inputSystem.Player.Look.ReadValue<Vector2>();

    public bool IsJumpPressed => _inputSystem.Player.Jump.IsPressed();


    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoved?.Invoke(context.ReadValue<Vector2>());
    }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        OnLooked?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) OnJumped?.Invoke();
    }
    private void EnsureInputSystemWasCreated()
    {
        if (_inputSystem == null) return;
        _inputSystem = new InputSystem();
        _inputSystem.Player.SetCallbacks(this);
    }
}
