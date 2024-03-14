using UnityEngine;

public class SprintState : State
{
    bool sprint;
    float moveSpeed = 10;
    
    public SprintState(Speler _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        sprint = false;
        input = Vector2.zero;       
    }
 
    public override void HandleInput()
    {
        base.HandleInput();
        input = moveAction.ReadValue<Vector2>();

        if (sprintAction.triggered)
        {
            sprint = false;
        }
        else
        {
            sprint = true;
        }
    }
 
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!sprint)
        {
            stateMachine.ChangeState(character.moving);
        }
    }
 
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        character.transform.Translate(new Vector3(input.x, 0, input.y) * (moveSpeed * 2) * Time.deltaTime);
    }
}