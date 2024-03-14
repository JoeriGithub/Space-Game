using UnityEngine;
 
public class MovingState : State
{
    bool jump;
    bool sprint;
    float moveSpeed = 5;
    
    private Quaternion lookRotation;
 
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

        Vector3 forward = character.GetComponent<Camera>().forward;
        Vector3 right = character.GetComponent<Camera>().right;
        
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

        // Move the hugger
        character.transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        //transform.LookAt(transform.position + direction);

        if (direction == Vector3.zero)
            return;
        
        // Rotate the hugger towards the direction it's headed
        direction.Normalize();
        lookRotation = Quaternion.LookRotation(direction);
        character.transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
 
    public override void Exit()
    {
        base.Exit();
    }
 
}
