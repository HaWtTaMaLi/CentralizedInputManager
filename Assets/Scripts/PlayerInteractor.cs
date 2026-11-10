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

            if (hit.collider.TryGetComponent<NPCBRO>(out var bro))
            {
                bro.InRange();
                currentInteractable = bro;
            }

            if (hit.collider.TryGetComponent<OpenDoor>(out var door))
            {
                door.InRange();
                currentInteractable = door;
            }

            if (hit.collider.TryGetComponent<LightPumpkin>(out var light))
            {
                light.InRange();
                currentInteractable = light;
            }
        }
        else
        {
            currentInteractable.OutofRange();
        }
    }
}
