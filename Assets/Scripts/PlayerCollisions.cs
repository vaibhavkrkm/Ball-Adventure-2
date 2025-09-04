using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            CollectibleManager collectible = collision.gameObject.GetComponent<CollectibleManager>();    // getting collectible manager reference

            if (collectible.collectibleName == "Light Crystal")    // what to do if collides with Light Crystal
            {

            }
            else if (collectible.collectibleName == "Heart")    // what to do if collides with Heart
            {

            }
            else if (collectible.collectibleName == "Coin")    // what to do if collides with Coin
            {

            }

            Destroy(collision.gameObject);    // destroy the collectible after collecting
        }
    }
}
