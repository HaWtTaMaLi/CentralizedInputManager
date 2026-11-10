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
    public Outline outline;

    //
    public string DisplayName => displayName;

    public bool CanInteract() => inRange;
    [SerializeField] private bool inRange = false;

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
        outline.enabled = true;
        inRange = true;
    }

    public void OutofRange()
    {
        //hide interact text, UIManager
        outline.enabled = false;
        inRange = false;
    }
}