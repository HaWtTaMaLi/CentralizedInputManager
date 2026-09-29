using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;

    public float moveSpeed = 5f;
    public float jumpForce = 3f;
    public float rotateSpeed = 1f;
    public float gravity = -9.81f; //defaut gravity 
    public float velocity;
    public float gravityMultiplier = 3;
    public Vector2 currentMovement; //to track current input for update functions
    public Vector2 currentDirection; //to track current input fo update functions
    public CharacterController playerController;

    public Transform cameraObject; 

    //so far best controlls ive ever put together!

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

    public void Update()
    {
        #region HandleMove

        //make movement a vector3
        Vector3 playermovement =
            (transform.right * currentMovement.x + transform.forward * currentMovement.y) * moveSpeed * Time.deltaTime; 
        //x.left/right, y.up/down, z.forward/back

        playermovement.y = velocity * Time.deltaTime;

        playerController.Move(playermovement);
        #endregion

        #region HandleLook

        //im looking around but not looking where im going
        transform.Rotate(0, currentDirection.x * rotateSpeed, 0);
        //added Transform.right and transform.forward to my playermovement
        //so now i can see where im going
        #endregion

        #region HandleGravity & Velocity

        if (playerController.isGrounded && velocity <= 0)
        {
            //Debug.Log("Update Velocity to 0");
            Debug.Log("Grounded "+velocity);
            velocity = 0;
        }
        else
        {
            Debug.Log("AirBorn"+velocity);
            velocity = velocity + (gravity * Time.deltaTime);
        }
        //my velocity keeps jumping between negative and and 0
        #endregion
    }

    public void HandleJump()
    {
        //jump
        //Debug.Log("Jumping");
        //if the player is already on the ground we can jump
        if (playerController.isGrounded)
        {
            Debug.Log("Jump velocity before = " + velocity);

            //player go up
            velocity = velocity + jumpForce;

            Debug.Log("Jump velocity after = " + velocity);
        }

    }

    public void HandleMove(Vector2 movement)
    {
        //move
        //Debug.Log("Moving");
        //Debug.Log(movement);

        //set currentMovement to movement
        //to track in Update Function
        currentMovement = movement;

        //moved to Update
        //make movement a vector3
        //Vector3 playermovement = new Vector3(movement.x, 0, movement.y); //x.left/right, y.up/down, z.forward/back

    }

    public void HandleLook(Vector2 lookDirection)
    {
        //look
        //Debug.Log("Looking");
        //Debug.Log(lookDirection);

        //set currentDirection to lookDirection
        //to track in Update Function
        currentDirection = lookDirection;
    }
}
