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
                CollectibleCollection lightCrystal = collision.gameObject.GetComponent<CollectibleCollection>();
                lightCrystal.CollectItem();
            }
            else if (collectible.collectibleName == "Heart")    // what to do if collides with Heart
            {
                CollectibleCollection heart = collision.gameObject.GetComponent<CollectibleCollection>();
                heart.CollectItem();
            }
            else if (collectible.collectibleName == "Coin")    // what to do if collides with Coin
            {
                CollectibleCollection coin = collision.gameObject.GetComponent<CollectibleCollection>();
                coin.CollectItem();
            }
        }
    }
}
