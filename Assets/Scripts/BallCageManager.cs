using UnityEngine;

public class BallCageManager : MonoBehaviour
{
    public string ballName;
    [Multiline] public string freeBallStoryline;

    public GameObject ball;
    public float ballTweenDuration = 1f;
    public Sprite veryHappySprite;

    private LevelManager levelManager;
    private Transform switchBallUITransform;

    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
        switchBallUITransform = GameObject.Find("ChangeBallStrip").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInteractor playerInteractor = collision.gameObject.GetComponent<PlayerInteractor>();
            playerInteractor.OnInteract += ShowFreeBallUI;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerInteractor playerInteractor = collision.gameObject.GetComponent<PlayerInteractor>();
            playerInteractor.OnInteract -= ShowFreeBallUI;
        }
    }

    private void ShowFreeBallUI()
    {
        levelManager.EnableFreeBallUI(this);
    }

    public void StartBallTween()
    {
        // Set the ball's sprite to very happy before tweening
        if (veryHappySprite != null)
        {
            ball.GetComponent<SpriteRenderer>().sprite = veryHappySprite;
        }
        else
        {
            Debug.LogWarning("Very Happy Sprite is null!");
        }

        // Get the screen position of the UI target.
        Vector3 targetScreenPosition = switchBallUITransform.position;

        // Set the Z-depth. This is a crucial step!
        // We need to tell the camera how far into the world to place the point.
        // For a 2D game, this is the distance from the camera to your gameplay plane.
        // If your camera is at z = -10, this value should be 10.
        //targetScreenPosition.z = -Camera.main.transform.position.z;

        // Convert the screen point to a world point.
        Vector3 targetWorldPosition = Camera.main.ScreenToWorldPoint(targetScreenPosition);

        // Use this correct world position for your tween.
        LeanTween.move(ball, targetWorldPosition, ballTweenDuration).setEaseInOutCubic().setOnComplete(DestroyCage);
    }

    public void DestroyCage()
    {
        Destroy(gameObject);
    }
}
