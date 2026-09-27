using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputManager _inputManager;
    public float walkSpeed = 5f;
    public float jumpSpeed = 3f;
    public Rigidbody playerRB;

    // private void Awake() => _inputManager.OnJumped += <Method>;
    // private void Awake() => _inputManager.OnMoved += <method>;
    // private void Awake() => _inputManager.OnLooked += <method>;

    //private void OnDisable() => _inputMager.OnJumped -= <Mathod>;
    //private void OnDisable() => _inputManager.OnMoved += <method>;
    //private void OnDisable() => _inputManager.OnLooked += <method>;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = _inputManager.Direction;
        Vector3 horizontal = (transform.right * direction.x + transform.forward * direction.y) * walkSpeed;
        playerRB.MovePosition(playerRB.position + transform.forward * Time.deltaTime);
    }


}
