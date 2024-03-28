using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RangedWeapon : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab; // Reference to the small block Prefab
    [SerializeField] private Transform launchPoint; // Transform representing the launch position of the small block
    [SerializeField] private float launchForce = 10f; // Force applied to launch the small block
    [SerializeField] private int magazineSize = 5; // Maximum number of bullets in the magazine
    [SerializeField] private float reloadTime = 2f; // Time in seconds for reloading


    private Rigidbody _rigidbody;
    private int currentAmmo; // Current number of bullets in the magazine
    private bool isReloading; // Flag to indicate if the launcher is reloading

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        currentAmmo = magazineSize;
    }
    void OnFire(InputValue value) // This method could be called by another script or event
    {
        if (currentAmmo > 0 && !isReloading)
        {
            // Create and launch a bullet
            GameObject bullet = Instantiate(BulletPrefab, launchPoint.position, launchPoint.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(launchPoint.forward * launchForce, ForceMode.Impulse);
            currentAmmo--; // Decrement current ammo
        }
        else if (!isReloading)
        {
            // Start reloading if out of ammo or already reloading
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        isReloading = true; // Set reloading flag to true
        yield return new WaitForSeconds(reloadTime); // Wait for reload time
        currentAmmo = magazineSize; // Refill magazine
        isReloading = false; // Set reloading flag to false
    }

    internal static void OnFire()
    {
        throw new NotImplementedException();
    }
}
