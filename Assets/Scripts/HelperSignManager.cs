using TMPro;
using UnityEngine;

public class HelperSignManager : MonoBehaviour
{
    public GameObject interactTextObject;
    [Multiline] public string helpText = "Sample Help Text";

    private void Start()
    {
        interactTextObject.SetActive(false);    // making sure the interact text is disabled when level starts
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // enabling the interact text
            interactTextObject.SetActive(true);
            // subscribing to player interact event when it comes near the sign
            PlayerInteractor playerInteractor = collision.gameObject.GetComponent<PlayerInteractor>();
            playerInteractor.OnInteract += ShowHelpUI;
        }
    }

    private void ShowHelpUI()
    {
        print(helpText);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // disabling the interact text
            interactTextObject.SetActive(false);

            // unsubscribing to player interact event when it moves away from the sign
            PlayerInteractor playerInteractor = collision.gameObject.GetComponent<PlayerInteractor>();
            playerInteractor.OnInteract -= ShowHelpUI;
        }
    }
}
