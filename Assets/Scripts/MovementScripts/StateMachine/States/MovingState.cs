using UnityEngine;
 
public class MovingState : State
{
    bool jump;
    bool sprint;
    float moveSpeed = 5;
    
    private Quaternion lookRotation;

    public Vector3 forward;
    public Vector3 right;
 
    public MovingState(Speler _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();

        jump = false;
        sprint = false;
        input = Vector2.zero; 
        mouseinput = Vector2.zero;
    }
 
    public override void HandleInput()
    {
        base.HandleInput();
 
        if (jumpAction.triggered)
        {
            jump = true;
        }
        if (sprintAction.triggered)
        {
            sprint = true;
        }
 
        input = moveAction.ReadValue<Vector2>();
        mouseinput = lookAction.ReadValue<Vector2>();

        forward = character.camera.transform.forward;
        right = character.camera.transform.right;
        
        forward.y = 0;
        right.y = 0;
    }
 
    public override void LogicUpdate()
    {
        base.LogicUpdate();
 
        if (sprint)
        {
            stateMachine.ChangeState(character.sprinting);
        }    
        if (jump)
        {
            stateMachine.ChangeState(character.jumping);
        }
        if (input == Vector2.zero) 
        {
            stateMachine.ChangeState(character.standing);
        }
    }
 
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
 
        // Determine what forwards is according to the camera
        Vector3 direction = forward * input.y + right * input.x;

        Vector3 velocity = direction * moveSpeed;

        character.rigidBody.velocity = velocity * Time.deltaTime;

        // Move the player
        //character.transform.Translate(velocity * Time.deltaTime, Space.World);
    }
 
    public override void Exit()
    {
        base.Exit();
    }
 
}
