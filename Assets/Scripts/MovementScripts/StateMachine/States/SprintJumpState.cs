using UnityEngine;
 
public class SprintJumpState : State
{
    bool grounded;
    float gravityValue;
    float jumpHeight;
    float playerSpeed;

    Vector3 airVelocity;
 
    public SprintJumpState(Speler _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        grounded = false;
        gravityValue = character.gravityValue;
        jumpHeight = character.jumpHeight;
        playerSpeed = character.playerSpeed;
        gravityVelocity.y = 0;

        input = Vector2.zero;

        Jump();
    }
    public override void HandleInput()
    {
        base.HandleInput();
        input = moveAction.ReadValue<Vector2>();
    }
 
    public override void LogicUpdate()
    {
        base.LogicUpdate();
 
        if (grounded && input == Vector2.zero)
        {
            stateMachine.ChangeState(character.standing);
        }
        if (grounded && input != Vector2.zero)
        {
            stateMachine.ChangeState(character.moving);
        }
    }
 
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (!grounded)
        {
 
            velocity = character.playerVelocity;
            airVelocity = new Vector3(input.x, 0, input.y);
 
            velocity = velocity.x * character.camera.right.normalized + velocity.z * character.camera.forward.normalized;
            velocity.y = 0f;
            airVelocity = airVelocity.x * character.camera.right.normalized + airVelocity.z * character.camera.forward.normalized;
            airVelocity.y = 0f;
            character.controller.Move(gravityVelocity * Time.deltaTime+ (airVelocity*character.airControl+velocity*(1- character.airControl))*(playerSpeed * 3)*Time.deltaTime);
        }
 
        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = character.controller.isGrounded;
    }
 
    void Jump()
    {
        gravityVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }
 
}