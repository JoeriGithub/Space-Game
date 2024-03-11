using UnityEngine;
 
public class MovingState : State
{
    bool jump;
    bool sprint;
    float moveSpeed = 5;
 
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
 
        character.transform.Translate(new Vector3(input.x, 0, input.y) * moveSpeed * Time.deltaTime);
    }
 
    public override void Exit()
    {
        base.Exit();
    }
 
}
