using UnityEngine;

public class NPCBRO : MonoBehaviour, IInteractable
{
    public GameObject npcbro;
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
        if (canInteract)
        {
            Destroy(npcbro);
            //+1 UI + text?
        }
    }

    public void Interact()
    {
        if (CanInteract())
        {
            InteractWithNPCBro();
        }
        else
        {
            Debug.Log("Can't Interact");
        }
    }

    public void InRange()
    {
        Debug.Log("Can Interact with Bro = " + canInteract);
        //outline.enabled = true;
        canInteract = true;
        //Interactable.Instance.InRange();
    }
    public void OutofRange()
    {
        Debug.Log("Can Interact  with bro = " + canInteract);

        //outline.enabled = false;
        canInteract = false;
        //Interactable.Instance.OutofRange();
    }

}
