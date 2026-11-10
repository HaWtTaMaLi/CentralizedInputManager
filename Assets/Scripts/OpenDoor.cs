using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour, IInteractable
{
    //
    public float rotationAmount = 90;
    public float rotationSpeed = 1;
    public float forwardDirection = 0;
    //
    public bool isOpen = false;
    private bool isRotating = true;
    //
    public Coroutine AnimationCoroutine;
    public Vector3 startRotation;
    public Vector3 forward;
    public Outline outline;

    //
    [SerializeField] private bool canInteract = false;
    public bool CanInteract() => canInteract; 
    //
    [SerializeField] private InputManager _inputManager;
    public void OnEnable() => _inputManager.OnInteracted += Interact;
    public void OnDisable() => _inputManager.OnInteracted -= Interact;

    public void Awake()
    {
        startRotation = transform.rotation.eulerAngles;
        forward = transform.forward;
    }

    public IEnumerator DoRotationOpen(float forwardAmount)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation;

        if (forwardAmount >= forwardDirection)
        {
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y - rotationAmount, 0));
        }
        else
        {
            endRotation = Quaternion.Euler(new Vector3(0, startRotation.y + rotationAmount, 0));
        }

        isOpen = true;

        float time = 0;
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * rotationSpeed;
        }
    }

    public IEnumerator DoRotationClose()
    {
        Quaternion StartRotation = transform.rotation;
        Quaternion endRotation = Quaternion.Euler(startRotation);

        isOpen = false;

        float time = 0;
        while(time < 1)
        {
            transform.rotation = Quaternion.Slerp(StartRotation, endRotation, time);
            yield return null;
            time += Time.deltaTime * rotationSpeed;
        }
    }

    public void Open(Vector3 UserPosition)
    {
        if (!isOpen)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if (isRotating)
            {
                float dot = Vector3.Dot(forward, (UserPosition - transform.position).normalized);
                //Debug.Log($"Dot: {dot.ToString("N3")}");
                AnimationCoroutine = StartCoroutine(DoRotationOpen(dot));
            }
        }
    }

    public void Close()
    {
        if (isOpen)
        {
            if(AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if (isRotating)
            {
                AnimationCoroutine = StartCoroutine(DoRotationClose());
            }
        }
    }

    public void ToggleDoor()
    {
        if (isOpen)
        {
            Close();
        }
        else
        {
            Open(transform.position);
        }
    }
    public void Interact()
    {
        if (CanInteract())
        {
            ToggleDoor();
        }
        else
        {
            Debug.Log("not in range.");
        }
    }

    public void InRange()
    {
        //can use to set up automatic doors
        outline.enabled = true;
        canInteract = true;
        Interactable.Instance.InRange();
        //Debug.Log("In Range " + CanInteract);
    }
    public void OutofRange()
    {

        outline.enabled = false;
        canInteract = false;
        Interactable.Instance.OutofRange();

        //Debug.Log("Out Of Range " + CanInteract);
    }
}
