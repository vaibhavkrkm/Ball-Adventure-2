using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public Animator animator;

    public int maxLives = 3;
    [HideInInspector] public int lives;
    [HideInInspector] public bool isInvincible = false;

    private void Start()
    {
        lives = maxLives;
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
        }
    }

    public void OnAnimationEnd(string animationName)
    {
        if (animationName == "PlayerHurt")
        {
            animator.SetBool("PlayerHurt", false);    // setting PlayerHurt parameter to false
            isInvincible = false;    // making the player vincible
        }
    }
}
