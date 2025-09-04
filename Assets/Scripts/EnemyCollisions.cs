using UnityEngine;

public class EnemyCollisions : MonoBehaviour
{
    public int playerBumpEffect = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // make the player jump when it stomps the enemy
            PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();
            playerMovement.ForceJump(playerBumpEffect);

            // destroy the enemy
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // make the player take damage
        PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
        playerStats.TakeDamage();
    }
}
