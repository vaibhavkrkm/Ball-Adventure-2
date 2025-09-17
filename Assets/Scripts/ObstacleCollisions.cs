using UnityEngine;

public class ObstacleCollisions : MonoBehaviour
{
    public int damage = 1;    // damage the obstacle will do
    public string type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))    // when the obstacle collides with player
        {
            PlayerBallLoader playerBallLoader = collision.gameObject.GetComponent<PlayerBallLoader>();
            bool immuneCondition = (playerBallLoader.currentBall.waterImmunity && type == "Water") ||
                                    (playerBallLoader.currentBall.metalImmunity && type == "Metal") ||
                                    (playerBallLoader.currentBall.lavaImmunity && type == "Lava");

            if (!immuneCondition)
            {
                PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
                playerStats.StartTakingDamage(damage);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))    // when player exits the obstacle
        {
            PlayerStats playerStats = collision.gameObject.GetComponent<PlayerStats>();
            playerStats.StopTakingDamage();
        }
    }
}
