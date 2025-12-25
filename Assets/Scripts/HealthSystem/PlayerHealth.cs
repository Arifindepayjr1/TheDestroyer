using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int health;

    public PlayerMovement playerMovement;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (playerMovement.IsDead) return;

        health -= amount;

        // Play Hurt animation
        if (playerMovement.animator != null)
            playerMovement.animator.SetTrigger("Hurt");

        if (health <= 0)
            playerMovement.Die();
    }

    public void RestoreHealth()
    {
        health = maxHealth;
    }
}
