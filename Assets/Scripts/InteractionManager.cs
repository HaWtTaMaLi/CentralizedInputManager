using UnityEngine;

[CreateAssetMenu(fileName = "InteractionManager", menuName = "Scriptable Objects/InteractionManager")]
public class InteractionManager : ScriptableObject
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
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, distance, targetLayer))
        {
            Debug.Log("Raycast hit: " + hit.collider.name);

        }
    }
}
