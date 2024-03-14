using UnityEngine;
using System.Collections;


public class Bullet : MonoBehaviour
{
    [SerializeField] private float destroyTime = 3f; // Time in seconds before destroying the sphere
    [SerializeField] private float raycastDistance = 1f; // Distance to raycast
    [SerializeField] private int BulletDamage = 10; // Damage that the bullet deals


    void Start()
    {
        StartCoroutine(DestroySphere());
    }

    IEnumerator DestroySphere()
    {
        yield return new WaitForSeconds(destroyTime); // Wait for the specified time
        Destroy(gameObject); // Destroy the current GameObject (sphere)
    }

    void Update()
    {
        // Raycast forward from the sphere's position
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            // Check if the hit object has the block tag
            if (hit.collider.gameObject.tag == "Enemy")
            {
                // Get the Enemy script from the hit object
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    // Deal damage to the block
                    enemy.TakeDamage(BulletDamage); // Change 10 to your desired damage amount
                    Destroy(gameObject);
                }
            }
        }
    }
}

