using UnityEngine;
using UnityEngine.InputSystem;

public class Speler : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the small block Prefab
    public Transform launchPoint; // Transform representing the launch position of the small block
    public float launchForce = 10f; // Force applied to launch the small block
    public int magazineSize = 5; // Maximum number of bullets in the magazine
    public float reloadTime = 2f; // Time in seconds for reloading 
    [SerializeField]
    public CapsuleCollider staan;
    [SerializeField]
    public CapsuleCollider crouch;

    public float playerSpeed = 5.0f;
    public float jumpHeight = 0.8f;

    public StateMachine movementSM;
    public IdleState standing;
    public JumpingState jumping;
    public CrouchingState crouching;
    public SprintState sprinting;
    public MovingState moving;
    public FiringState firing;

    [Range(0, 1)]
    public float velocityDampTime = 0.9f;
    [Range(0, 1)]
    public float rotationDampTime = 0.2f;
    [Range(0, 1)]
    public float airControl = 0.5f;
 
    [HideInInspector]
    public PlayerInput playerInput;
    //[HideInInspector]
    //public Rigidbody rigidBody;
    [HideInInspector]
    public CharacterController controller;
    [HideInInspector]
    public Transform camera;
    [HideInInspector]
    public Vector3 playerVelocity;
    [HideInInspector]
    public float gravityValue = -9.81f;
 
    // Start is called before the first frame update
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        //rigidBody = GetComponent<Rigidbody>();
        camera = Camera.main.transform;
 
        movementSM = new StateMachine();
        standing = new IdleState(this, movementSM);
        moving = new MovingState(this, movementSM);
        jumping = new JumpingState(this, movementSM);
        crouching = new CrouchingState(this, movementSM);
        sprinting = new SprintState(this, movementSM);
        firing = new FiringState(this, movementSM);        
 
        movementSM.Initialize(standing);
    }
 
    private void Update()
    {
        movementSM.currentState.HandleInput();
 
        movementSM.currentState.LogicUpdate();
    }
 
    private void FixedUpdate()
    {
        movementSM.currentState.PhysicsUpdate();
    }
}
 
