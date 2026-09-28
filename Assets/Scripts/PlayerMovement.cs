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
    }

    public void HandleMove()
    {
        //move
    }

    public void HandleLook()
    {
        //look
    }
}
