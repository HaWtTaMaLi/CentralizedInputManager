using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //Canvases
    public Canvas interactCanvas;

    public void Awake()
    {
        if (Instance == null && Instance == this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        HideAllCanvases();
    }

    //Canvas Actions
    public void ShowInteractCanvas()
    {
        interactCanvas.enabled = true;
    }

    public void HideAllCanvases()
    {
        interactCanvas.enabled = false;
    }
}
