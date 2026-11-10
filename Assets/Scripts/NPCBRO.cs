using UnityEngine;

public class NPCBRO : MonoBehaviour, IInteractable
{
    //
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private bool canInteract = false;
    public Outline outline;

    public bool CanInteract() => canInteract;

    public void OnEnable() => _inputManager.OnInteracted += Interact;
    public void OnDisable() => _inputManager.OnInteracted -= Interact;

    public void InteractWithNPCBro()
    {
        Debug.Log("Interacted with NPC Bro");
    }

    public void Interact()
    {
        if (CanInteract())
        {
            InteractWithNPCBro();
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
