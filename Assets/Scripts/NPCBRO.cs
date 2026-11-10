using TMPro;
using UnityEngine;

public class NPCBRO : MonoBehaviour, IInteractable
{
    public bool CanInteract() => canInteract;
    public GameObject npcbro;
    private Outline outline;
    public TMP_Text broCountText;
    public int broCount = 0;

    public bool isBro = true;
    [SerializeField] private bool canInteract = false;

    public void Awake()
    {
        //Set the outline component to the object
        outline = gameObject.AddComponent<Outline>();
        //Initialize the outline component
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.white;
        outline.OutlineWidth = 3f;
        //Disable the outline component on Awake
        outline.enabled = false;
    }
    public void InteractWithNPCBro()
    {
        Debug.Log("Interacted with NPC Bro");

        if (isBro)
        {
            isBro = false;
            broCount++;
            broCountText.text = broCount.ToString();
            UIManager.Instance.countCanva.enabled = true;
            npcbro.SetActive(false);
        }
        else
        {
            isBro = true;
            npcbro.SetActive(true);
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
        outline.enabled = true;
        canInteract = true;
    }
    public void OutofRange()
    {
        outline.enabled = false;
        canInteract = false;
    }
}
