using UnityEngine;

public class NPCBRO : MonoBehaviour, IInteractable
{
    //
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private bool isEnabled = false;
    public bool CanInteract() => isEnabled;

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
        isEnabled = true;
    }
    public void OutofRange()
    {
        isEnabled = false;
    }

}
