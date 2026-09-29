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

    public void OnDisable() => _inputSystem?.Player.Disable(); // disable input that was enabled in EnsureInputSystemWasCreated

    public void OnMove(InputAction.CallbackContext context)
    {
        //Debug.Log("InputManager recived Move"); //Works
        //Debug.Log(context); //used this to check if readvalue was getting -
        //- the phase "cancelled" to make sure i dont need to add any extra -
        //- inputs, it does say "cancelled"
        
        OnMoved?.Invoke(context.ReadValue<Vector2>());
    }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        //Debug.Log("InputManager recived Look"); //Works

        OnLooked?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("InputManager recived Jump"); //Works

        if (context.phase == InputActionPhase.Performed)
        {
            //Debug.Log("Invoking OnJumped"); //Works

            OnJumped?.Invoke();
        }
    }

    public void EnsureInputSystemWasCreated()
    {
        if (_inputSystem == null)
        {
            _inputSystem = new InputSystem();
            _inputSystem.Player.SetCallbacks(instance: this);
            _inputSystem.Player.Enable(); //needed this enabled to work inside of PlayerMovement
        }
    }
}
