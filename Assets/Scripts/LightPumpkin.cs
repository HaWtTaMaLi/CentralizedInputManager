using UnityEngine;

public class LightPumpkin : MonoBehaviour, IInteractable
{
    //
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private bool isEnabled = false;
    public bool CanInteract() => isEnabled;


    public void TogglePumpkinLight()
    {
        Debug.Log("Light Toggled");
    }

    public void Interact()
    {
        if (CanInteract())
        {
            TogglePumpkinLight();
        }
        else
        {
            Debug.Log("not in range.");
        }
    }

    public void InRange()
    {
        isEnabled = true;
    }
    public void OutofRange()
    {
        isEnabled = false;
    }
}
