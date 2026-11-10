using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    //Canvases
    public Canvas countCanvas;

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

    }

    public void HideAllCanvases()
    {

    }

    public void ShowCountCanvas()
    {
        countCanva.enabled = true;
    }
}
