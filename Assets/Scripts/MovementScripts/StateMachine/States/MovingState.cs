using UnityEngine;
 
public class MovingState : State
{
    bool jump;
    bool sprint;
    float moveSpeed = 5;
    float gravityValue;
    
    private Quaternion lookRotation;

    public Vector3 currentVelocity;
    public Vector3 cVelocity;
 
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

        velocity = new Vector3(input.x, 0, input.y);
 
        velocity = velocity.x * character.camera.right.normalized + velocity.z * character.camera.forward.normalized;
        velocity.y = 0f;

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

        gravityVelocity.y += gravityValue * Time.deltaTime;

        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity,ref cVelocity, character.velocityDampTime);
        character.controller.Move(currentVelocity * Time.deltaTime * moveSpeed + gravityVelocity * Time.deltaTime);
  
        if (velocity.sqrMagnitude>0)
        {
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(velocity),character.rotationDampTime);
        }
    }
 
    public override void Exit()
    {
        base.Exit();
    }
 
}
