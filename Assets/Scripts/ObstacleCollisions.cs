using UnityEngine;

public class ObstacleCollisions : MonoBehaviour
{
    public int damage = 1;    // damage the obstacle will do

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))    // when the obstacle collides with player
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            playerStats.TakeDamage(damage);
        }
    }
}
