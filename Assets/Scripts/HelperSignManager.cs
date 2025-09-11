using TMPro;
using UnityEngine;

public class HelperSignManager : MonoBehaviour
{
    [Multiline] public string helpText = "Sample Help Text";

    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();    // getting level manager reference
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // subscribing to player interact event when it comes near the sign
            PlayerInteractor playerInteractor = collision.gameObject.GetComponent<PlayerInteractor>();
            playerInteractor.OnInteract += ShowHelpUI;
        }
    }

    private void ShowHelpUI()
    {
        levelManager.EnableHelpUI(helpText);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // unsubscribing to player interact event when it moves away from the sign
            PlayerInteractor playerInteractor = collision.gameObject.GetComponent<PlayerInteractor>();
            playerInteractor.OnInteract -= ShowHelpUI;
        }
    }
}
