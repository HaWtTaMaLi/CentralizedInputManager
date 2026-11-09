using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    //
    public InputManager _inputManager;
    public Transform playerCamera;
    public float interactionDistance = 5f;
    //set the layers in the inspector
    public LayerMask interactableLayer;

    public IInteractable currentInteractable;

    public void Update()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactableLayer))
        {
            // Check if the hit object has an IInteractable component
            if (hit.collider.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.InRange();
                currentInteractable = interactable;
            }
            //check if the hit object has an OpenDoor componenet
            if (hit.collider.TryGetComponent<OpenDoor>(out var door))
            {
                door.InRange();
                currentInteractable = door;
            }
        }
        else
        {
            currentInteractable.OutofRange();
        }
    }
}
