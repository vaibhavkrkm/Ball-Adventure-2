using System;
using UnityEngine;

public class ButtonSignManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite buttonOnSprite;
    public Sprite buttonOffSprite;
    public GameObject platform;
    public Transform whereToMove;

    [Header("Button Properties")]
    public string movementType;    // "Toggle or Timed"
    public float moveTime;
    public float waitTime;    // only for timed movement type

    private LevelManager levelManager;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private Vector3 initialPosition;
    private bool platformAtTarget = false;

    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    private void Start()
    {
        initialPosition = platform.transform.position;
        targetPosition = whereToMove.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInteractor playerInteractor = collision.gameObject.GetComponent<PlayerInteractor>();
            playerInteractor.OnInteract += PerformButtonOperation;
        }
    }

    private void PerformButtonOperation()
    {
        if (isMoving) return;

        if (movementType == "Toggle")
        {
            ToggleMovement();
        }
        else if (movementType == "Timed")
        {
            TimedMovement();
        }
    }

    private void ToggleMovement()
    {
        isMoving = true;
        spriteRenderer.sprite = buttonOnSprite;

        // setting destination as per the current platform status
        Vector3 destination;
        if (platformAtTarget)
        {
            destination = initialPosition;
        }
        else
        {
            destination = targetPosition;
        }

        // using lean tween to smoothly move the platform
        LeanTween.move(platform, destination, moveTime).setEaseInOutQuad().setOnComplete(() =>
        {
            isMoving = false;
            spriteRenderer.sprite = buttonOffSprite;
            platformAtTarget = !platformAtTarget;
        });
    }

    private void TimedMovement()
    {
        isMoving = true;
        spriteRenderer.sprite = buttonOnSprite;

        Vector3 destination = targetPosition;

        LeanTween.move(platform, destination, moveTime).setEaseInOutQuad().setOnComplete(() =>
        {
            LeanTween.delayedCall(waitTime, () =>
            {
                destination = initialPosition;
                LeanTween.move(platform, destination, moveTime).setEaseInOutQuad().setOnComplete(() =>
                {
                    isMoving = false;
                    spriteRenderer.sprite = buttonOffSprite;
                });
            });
        });
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInteractor playerInteractor = collision.gameObject.GetComponent<PlayerInteractor>();
            playerInteractor.OnInteract -= PerformButtonOperation;
        }
    }
}
