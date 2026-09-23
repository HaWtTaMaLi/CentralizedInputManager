using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class InputEvents
{
    public string InputName;
    public UnityEvent InputEvent;
}

    //all input actions go here and other scripts can subscribe to them

public class InputManager : MonoBehaviour
{
    public InputEvents[] AllEvents;

    public static Action onMove; //PlayerManager
    public static Action onInteract; //InteractableObject
    public static Action onPause; //UIManager

    public InputAction playerMovement;
    public InputAction interactable;
    public InputAction pause;

    public void Start()
    {

        //playerMovement.performed.AddListener(() => AllEvents[1].InputEvent.Invoke());
        //or something like this
    }

    public void OnMove()
    {
        if (onMove != null)
        {
            onMove.Invoke();
        }
    }
    public void OnInteract()
    {
        if (onInteract != null)
        {
            onInteract.Invoke();
        }
    }

    public void OnPause()
    {
        if (onPause != null)
        {
            onPause.Invoke();
        }
    }

}
