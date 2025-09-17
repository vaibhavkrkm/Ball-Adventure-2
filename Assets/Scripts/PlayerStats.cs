using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Animator animator;
    public GameObject lifeBar;
    public PlayerBallLoader playerBallLoader;
    public SpriteRenderer spriteRenderer;

    public int maxLives = 3;
    public float hurtAnimationTime = 1.5f;
    [HideInInspector] public int lives;
    [HideInInspector] public bool isTakingDamage = false;

    private LevelManager levelManager;
    private Coroutine playerDamageCoroutine;

    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }

    private void Start()
    {
        lives = maxLives;
    }

    public void StartTakingDamage(int damage=1)
    {
        if (!isTakingDamage)
        {
            isTakingDamage = true;
            if (playerDamageCoroutine == null)    // only start the coroutine when not already running
            {
                playerDamageCoroutine = StartCoroutine(TakeDamage(damage));
            }
        }
    }

    public void StopTakingDamage()
    {
        isTakingDamage = false;
    }

    public IEnumerator TakeDamage(int damage)
    {
        while (isTakingDamage)
        {
            lives -= damage;
            UpdateLifebar();

            animator.SetBool("PlayerHurt", true);    // start player hurt animation
            spriteRenderer.sprite = playerBallLoader.currentBall.surprisedSprite;    // change player sprite to surprised

            // if lives <= 0, perform gameover operation
            if (lives <= 0)
            {
                spriteRenderer.sprite = playerBallLoader.currentBall.deadSprite;
                levelManager.GameOver();
                yield break;    // stop coroutine
            }

            yield return new WaitForSeconds(hurtAnimationTime + 0.1f);    // wait till invincible

            // stop player hurt animation and change the player sprite back before starting the coroutine again
            animator.SetBool("PlayerHurt", false);
            UpdateSpriteBasedOnHealth();
            yield return null;
        }

        // setting the playerDamageCoroutine to null before finishing it
        playerDamageCoroutine = null;
        yield break;
    }

    private void UpdateSpriteBasedOnHealth()
    {
        if (lives > 1)
        {
            spriteRenderer.sprite = playerBallLoader.currentBall.happySprite;
        }
        else if (lives == 1)
        {
            spriteRenderer.sprite = playerBallLoader.currentBall.sadSprite;
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
}
