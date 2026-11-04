using UnityEngine;

[CreateAssetMenu(fileName = "InteractionManager", menuName = "Scriptable Objects/InteractionManager")]
public class InteractionManager : ScriptableObject, IInteractable
{
    [SerializeField] private InputManager _inputManager;
    public float distance = 5;
    public LayerMask targetLayer = 3;//specify the layer 

    public void OnEnable()
    {
        _inputManager.OnInteracted += HandleInteraction;
    }

    public void OnDestroy()
    {
        _inputManager.OnInteracted -= HandleInteraction;
    }

    public void HandleInteraction()
    {
        //Debug.Log("InteractionManager received Interact");
        if(UIManager.Instance.interactCanvas.enabled == true)
        {
            UIManager.Instance.enabled = false;
        }
        else
        {
            UIManager.Instance.enabled = true;
        }
    }

    public void Interact()
    {
        HandleInteraction();
    }
}
