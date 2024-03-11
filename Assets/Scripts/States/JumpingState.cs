using UnityEngine;
 
public class JumpingState : State
{
    bool grounded;
    float moveSpeed = 10;
 
    public JumpingState(Speler _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        grounded = false;
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
 
        if (grounded)
        {
            stateMachine.ChangeState(character.moving);
        }
    }
 
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        character.transform.Translate(new Vector3(input.x, 0, input.y) * moveSpeed * Time.deltaTime);
        grounded = character.rigidBody.velocity.y == 0;
    }
 
    void Jump()
    {
        character.rigidBody.AddForce(new Vector3(0, 4, 0), ForceMode.Impulse);
    }
 
}
