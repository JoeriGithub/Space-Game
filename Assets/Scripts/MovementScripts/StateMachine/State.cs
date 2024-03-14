using UnityEngine;
using UnityEngine.InputSystem;
 
public class State
{
    public Speler character;
    public StateMachine stateMachine;
 
    protected Vector2 input;
 
    public InputAction moveAction;
    public InputAction jumpAction;
    public InputAction crouchAction;
    public InputAction sprintAction;
 
    public State(Speler _character, StateMachine _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
 
        moveAction = character.playerInput.actions["Move"];
        jumpAction = character.playerInput.actions["Jump"];
        crouchAction = character.playerInput.actions["Crouch"];
        sprintAction = character.playerInput.actions["Sprint"];
    }
 
    public virtual void Enter()
    {
        Debug.Log("Entering State: " + this.ToString());
    }
 
    public virtual void HandleInput()
    {
    }
 
    public virtual void LogicUpdate()
    {
    }
 
    public virtual void PhysicsUpdate()
    {
    }
 
    public virtual void Exit()
    {
    }
}