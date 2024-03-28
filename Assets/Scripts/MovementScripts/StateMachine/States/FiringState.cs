using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FiringState : State
{
    private GameObject bulletPrefab;
    private Transform launchPoint;
    private float launchForce;
    private int magazineSize;
    private float reloadTime;
    private int currentAmmo;
    private bool isReloading;

    bool fired;

    public FiringState(Speler _character, StateMachine _stateMachine) : base(_character, _stateMachine)
    {
        character = _character;
        stateMachine = _stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        currentAmmo = magazineSize;
        FireBullet();
    }

    public override void HandleInput()
    {
        base.HandleInput();

        fired = true;
        if (fireAction.triggered)
        {
            if (currentAmmo > 0 && !isReloading)
            {
                // Fire the weapon
                FireBullet();
            }
            else if (!isReloading)
            {
                // Start reloading if out of ammo
                //StartCoroutine(Reload());
            }
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (fired)
        {
            stateMachine.ChangeState(character.standing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
    }

    private void FireBullet()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, launchPoint.position, launchPoint.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);
        currentAmmo--;
        fired = true;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = magazineSize;
        isReloading = false;
    }
}
