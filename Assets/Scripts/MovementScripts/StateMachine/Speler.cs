using UnityEngine;
using UnityEngine.InputSystem;

public class Speler : MonoBehaviour
{
 
    [SerializeField]
    public CapsuleCollider staan;
    [SerializeField]
    public CapsuleCollider crouch;
    [SerializeField] 
    private float rotationSpeed = 10;
    [SerializeField] 
    new private Transform camera;

    public StateMachine movementSM;
    public IdleState standing;
    public JumpingState jumping;
    public CrouchingState crouching;
    public SprintState sprinting;
    public MovingState moving;
 
    [HideInInspector]
    public PlayerInput playerInput;
    [HideInInspector]
    public Rigidbody rigidBody;
 
    // Start is called before the first frame update
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
 
        movementSM = new StateMachine();
        standing = new IdleState(this, movementSM);
        moving = new MovingState(this, movementSM);
        jumping = new JumpingState(this, movementSM);
        crouching = new CrouchingState(this, movementSM);
        sprinting = new SprintState(this, movementSM);
 
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
 
