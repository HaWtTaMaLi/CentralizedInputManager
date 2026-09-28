using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;

    public float moveSpeed = 5f;
    public float jumpSpeed = 3f;

    public CharacterController playerController;

    private void Awake() 
    { 
        playerController = GetComponent<CharacterController>();
    }

    public void OnEnable() => _inputManager.OnJumped += HandleJump;

    private void OnDisable() => _inputManager.OnJumped -= HandleJump;

    public void HandleJump()
    {
        //jump
        Debug.Log("Jumpping");
    }

    public void HandleMove()
    {
        //move
        Debug.Log("Moving");
    }

    public void HandleLook()
    {
        //look
        Debug.Log("Looking");
    }
}
