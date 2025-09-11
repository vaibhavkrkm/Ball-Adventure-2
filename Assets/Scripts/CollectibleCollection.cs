using UnityEngine;

public class CollectibleCollection : MonoBehaviour
{
    public float scaleDivisionFactor = 0;
    public Color color = Utils.HexToColor("FFFFFF");

    public void CollectItem()
    {
        transform.localScale = transform.localScale / scaleDivisionFactor;
        GetComponent<SpriteRenderer>().color = color;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Animator>().SetBool("Collected", true);
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
