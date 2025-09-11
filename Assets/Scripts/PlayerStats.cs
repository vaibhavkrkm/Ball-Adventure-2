using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Animator animator;
    public GameObject lifeBar;
    public PlayerBallLoader playerBallLoader;
    public SpriteRenderer spriteRenderer;

    public int maxLives = 3;
    [HideInInspector] public int lives;
    [HideInInspector] public bool isInvincible = false;

    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    private void Start()
    {
        lives = maxLives;
        UpdateLifebar();
    }

    public void TakeDamage(int damage=1)
    {
        // only take damage if not invincible
        if (!isInvincible)
        {
            isInvincible = true;    // making player invincible for a short time after taking damage
            lives -= damage;

            // setting PlayerHurt parameter to true to start the PlayerHurt animation
            animator.SetBool("PlayerHurt", true);

            // setting sprite to surprised when player takes damage
            spriteRenderer.sprite = playerBallLoader.currentBall.surprisedSprite;

            // updating lifebar
            UpdateLifebar();

            if (lives <= 0)
            {
                // setting sprite to surprised when player takes damage
                spriteRenderer.sprite = playerBallLoader.currentBall.deadSprite;
                levelManager.GameOver();
            }
        }
    }

    // method to update the life bar when player takes damage
    private void UpdateLifebar()
    {
        foreach (Transform lifebarChild in lifeBar.transform)
        {
            if (lives == 3 && lifebarChild.name == "Life3")
            {
                lifebarChild.gameObject.SetActive(true);
            }
            else if (lives == 2 && lifebarChild.name == "Life2")
            {
                lifebarChild.gameObject.SetActive(true);
            }
            else if (lives == 1 && lifebarChild.name == "Life1")
            {
                lifebarChild.gameObject.SetActive(true);
            }
            else
            {
                lifebarChild.gameObject.SetActive(false);
            }
        }
    }

    public void OnAnimationEnd(string animationName)
    {
        if (animationName == "PlayerHurt")
        {
            animator.SetBool("PlayerHurt", false);    // setting PlayerHurt parameter to false
            isInvincible = false;    // making the player vincible

            if (lives > 1)
            {
                // setting sprite to happy again
                spriteRenderer.sprite = playerBallLoader.currentBall.happySprite;
            }
            else if (lives == 1)
            {
                // setting sprite to happy again
                spriteRenderer.sprite = playerBallLoader.currentBall.sadSprite;
            }
        }
    }
}
