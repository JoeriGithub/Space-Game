using UnityEngine;
 
public class CrouchingState : State
{
    bool crouchrelease;
    bool grounded;
    float moveSpeed = 200;
    float gravityValue;

    Vector3 currentVelocity;

    public CrouchingState(Speler _character, StateMachine _stateMachine):base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        crouchrelease = false;
        character.controller.height = character.crouchColliderHeight;
        character.controller.center = new Vector3(0f, character.crouchColliderHeight / 2f, 0f);
        grounded = character.controller.isGrounded;

        gravityValue = character.gravityValue;
    }
 
    public override void Exit()
    {
        base.Exit();

        //Vector3 newPosition = character.transform.position;
        //newPosition.y += 1f;
        //character.transform.position = newPosition;
        character.controller.Move(Vector3.up * (character.normalColliderHeight - character.crouchColliderHeight) * 1f);
        character.controller.height = character.normalColliderHeight;
        character.controller.center = new Vector3(0f, character.normalColliderHeight / 2f, 0f);
    }
 
    public override void HandleInput()
    {
        base.HandleInput();
        if (crouchAction.triggered)
        {
            crouchrelease = true;
        }
        input = moveAction.ReadValue<Vector2>();
        velocity = new Vector3(input.x, 0, input.y);

        velocity = velocity.x * character.camera.right.normalized + velocity.z * character.camera.forward.normalized;
        velocity.y = 0f;
    }
 
    public override void LogicUpdate()
    {
        base.LogicUpdate();
 
        if (crouchrelease)
        {
            stateMachine.ChangeState(character.standing);
        }
    }
 
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        gravityVelocity.y += gravityValue * Time.deltaTime;
        grounded = character.controller.isGrounded;
        if (grounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = 0f;
        }
        currentVelocity = Vector3.Lerp(currentVelocity, velocity, character.velocityDampTime);

        character.controller.SimpleMove(currentVelocity * Time.deltaTime * moveSpeed + gravityVelocity * Time.deltaTime);

        if (velocity.magnitude > 0)
        {
            character.transform.rotation = Quaternion.Slerp(character.transform.rotation, Quaternion.LookRotation(velocity), character.rotationDampTime);
        }
    }
}