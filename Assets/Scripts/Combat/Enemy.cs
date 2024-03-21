using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int maxHP = 100; // Maximum health points of the block
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHP; // Set initial health
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce health by damage amount

        if (currentHealth <= 0)
        {
            // Block destroyed (adjust as needed)
            Destroy(gameObject);
        }
    }

    // Optional: Function to access current health for UI or other purposes
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
