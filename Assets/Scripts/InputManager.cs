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

    public void OnEnable() => EnsureInputSystemWasCreated();

    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("InputManager recived Move");
        OnMoved?.Invoke(context.ReadValue<Vector2>());
    }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("InputManager recived Look");
        OnLooked?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("InputManager recived Jump");
        if (context.phase == InputActionPhase.Performed) OnJumped?.Invoke();
    }

    public void EnsureInputSystemWasCreated()
    {
        if (_inputSystem == null)
        {
            _inputSystem = new InputSystem();
            _inputSystem.Player.SetCallbacks(instance: this);
            _inputSystem.Player.Enable();
        }
    }
}
