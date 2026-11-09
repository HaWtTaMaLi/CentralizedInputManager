using UnityEngine;
using UnityEngine.Events;

public interface IInteractable
{
    bool CanInteract();
    void Interact();
    void InRange();
    void OutofRange();
}

public class Interactable : MonoBehaviour, IInteractable
{
    public static Interactable Instance;
    //
    [SerializeField] private string displayName = "Interact";
    [SerializeField] private UnityEvent onInteract;
    private Outline outline;

    //
    public string DisplayName => displayName;

    public bool CanInteract() => isEnabled;
    [SerializeField] private bool isEnabled = false;

    //
    public void Awake()
    {
        //
        if (Instance == null && Instance == this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        //Set the outline component to the object
        outline = gameObject.AddComponent<Outline>();
        //Initialize the outline component
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.white;
        outline.OutlineWidth = 3f;
        //Disable the outline component on Awake
        outline.enabled = false;
    }

    public void Interact()
    {
        //"Invoke"
    }

    public void InRange()
    {
        //show interact text, UIManager
        isEnabled = true;
        outline.enabled = true;
    }

    public void OutofRange()
    {
        //hide interact text, UIManager
        isEnabled = false;
        outline.enabled = false;
    }
}