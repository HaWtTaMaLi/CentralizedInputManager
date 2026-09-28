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

    public void OnEnable()
    {
       //Debug.Log("PlayerMovement subscribed to Jump");
        _inputManager.OnJumped += HandleJump;
        _inputManager.OnMoved += HandleMove;
        _inputManager.OnLooked += HandleLook;
    }

    private void OnDisable()
    {
        //Debug.Log("PlayerMovement unsubscribed to Jump");
        _inputManager.OnJumped -= HandleJump;
        _inputManager.OnMoved -= HandleMove;
        _inputManager.OnLooked -= HandleLook;

    }

    public void HandleJump()
    {
        //jump
        Debug.Log("Jumpping");
    }

    public void HandleMove(Vector2 movement)
    {
        //move
        Debug.Log("Moving");
    }

    public void HandleLook(Vector2 lookDirection)
    {
        //look
        Debug.Log("Looking");
    }
}
