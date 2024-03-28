using UnityEngine;

public class SprintState : State
{
    bool sprint;
    bool jump;
    float moveSpeed = 500;
    float gravityValue;
    
    private Quaternion lookRotation;

    public Vector3 currentVelocity;
    public Vector3 cVelocity;
    
    public SprintState(Speler _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        sprint = false;
        jump = false;
        input = Vector2.zero;       
    }
 
    public override void HandleInput()
    {
        base.HandleInput();
        input = moveAction.ReadValue<Vector2>();

        if (jumpAction.triggered)
        {
            jump = true;
        }
        if (sprintAction.triggered)
        {
            sprint = false;
        }
        else
        {
            sprint = true;
        }

        velocity = new Vector3(input.x, 0, input.y);
 
        velocity = velocity.x * character.camera.right.normalized + velocity.z * character.camera.forward.normalized;
        velocity.y = 0f;
    }
 
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!sprint)
        {
            stateMachine.ChangeState(character.moving);
        }
        if (jump)
        {
            stateMachine.ChangeState(character.sprintJump);
        }
    }
 
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        gravityVelocity.y += gravityValue * Time.deltaTime;

        currentVelocity = Vector3.SmoothDamp(currentVelocity, velocity,ref cVelocity, character.velocityDampTime);
        character.controller.SimpleMove(currentVelocity * Time.deltaTime * moveSpeed + gravityVelocity * Time.deltaTime);
  
        if (velocity.sqrMagnitude>0)
        {
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(velocity),character.rotationDampTime);
        }
    }
}