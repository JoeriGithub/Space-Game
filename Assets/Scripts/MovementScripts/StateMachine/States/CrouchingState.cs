using UnityEngine;
 
public class CrouchingState : State
{
    bool crouchrelease;
 
    public CrouchingState(Speler _character, StateMachine _stateMachine):base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }
 
    public override void Enter()
    {
        base.Enter();
 
        crouchrelease = false;
    }
 
    public override void Exit()
    {
        
    }
 
    public override void HandleInput()
    {
        base.HandleInput();
        if (crouchAction.triggered)
        {
            crouchrelease = true;
        }
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
        
        if (character.crouch.enabled)
        {
            character.crouch.enabled = false;
            character.staan.enabled = true;
        }
        else
        {
            character.staan.enabled = false;
            character.crouch.enabled = true;
        }
    }
}