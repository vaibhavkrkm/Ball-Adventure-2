using UnityEngine;

public class InteractTextManager : MonoBehaviour
{
    public GameObject interactTextObject;

    private void Start()
    {
        // disabling interact text in the beginning
        interactTextObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactTextObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactTextObject.SetActive(false);
        }
    }
}
