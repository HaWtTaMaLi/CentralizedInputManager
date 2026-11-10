using UnityEngine;

public class LightPumpkin : MonoBehaviour, IInteractable
{
    //
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private bool canInteract = false;
    public Outline outline;

    //
    public bool CanInteract() => canInteract;
    //
    public GameObject lightComponent;
    public bool isOn = false;
    //
    public void OnEnable() => _inputManager.OnInteracted += Interact;
    public void OnDisable() => _inputManager.OnInteracted -= Interact;

    public void LightOn()
    {
        isOn = true;
        lightComponent.SetActive(true);
    }

    public void LightOff()
    {
        isOn = false;
        lightComponent.SetActive(false);
    }

    public void TogglePumpkinLight()
    {
        Debug.Log("Light Toggled");
        if(isOn)
        {
            LightOff();
        }
        else
        {
            LightOn();
        }
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
        outline.enabled = true;
        canInteract = true;
        Interactable.Instance.InRange();
    }
    public void OutofRange()
    {
        outline.enabled = false;
        canInteract = false;
        Interactable.Instance.OutofRange();
    }
}
