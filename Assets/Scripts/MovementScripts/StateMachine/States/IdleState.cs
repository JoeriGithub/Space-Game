using UnityEngine;
 
public class IdleState : State
{
      
    bool crouch;
    bool move;
    bool fire;
 
    public IdleState(Speler _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        crouch = false;
        move = false; 
        fire = false;
    }
 
    public override void HandleInput()
    {
        base.HandleInput();

        if (crouchAction.triggered)
        {
            crouch = true;
        }
        if (moveAction.triggered)
        {
            move = true;
        }
        if (fireAction.triggered)
        {
            fire = true;
        }
    }
 
    public override void LogicUpdate()
    {
        base.LogicUpdate();
 
        if (crouch)
        {
            stateMachine.ChangeState(character.crouching);
        }
        if (move)
        {
            stateMachine.ChangeState(character.moving);
        }
        if (fire)
        {
            stateMachine.ChangeState(character.firing);
        }
    }
 
    public override void PhysicsUpdate()
    {
        
    }
 
    public override void Exit()
    {

    }
 
}
