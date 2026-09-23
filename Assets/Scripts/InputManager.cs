using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

    public Vector2 playerMovement;
    public Button interactable;
    public Button pause;

    public void Start()
    {
        //input actions go in this script 
        //the speed and other details go in the other 

        //playerMovement.performed.AddListener(() => AllEvents[1].InputEvent.Invoke());
        //or something like this

    }

    public void Move()
    {

    }

    public void Interact()
    {

    }

    public void Pause()
    {

    }
}