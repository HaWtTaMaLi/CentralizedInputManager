using System;
using UnityEngine;
using UnityEngine.Events;

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
}
