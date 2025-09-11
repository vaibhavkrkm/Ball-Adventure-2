using UnityEngine;

public class PlayerBallLoader : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public BallDatabase ballDatabase;
    public PlayerMovement playerMovement;

    [HideInInspector] public PlayerBall currentBall;

    private void Start()
    {
        LoadBall();
    }

    public void LoadBall()
    {
        currentBall = ballDatabase.GetBall(Global.selectedBall);

        if (currentBall != null)
        {
            spriteRenderer.sprite = currentBall.happySprite;    // enabling happy sprite

            // setting current ball properties
            playerMovement.acceleration = currentBall.ballAcceleration;
            playerMovement.maxJumpSpeed = currentBall.ballJumpPower;
            playerMovement.maxSpeed = currentBall.ballMaxSpeed;
        }
        else
        {
            // if the given ball was not found, set the default ball to Jumpy
            currentBall = ballDatabase.GetBall("Jumpy");

            // enabling jumpy happy sprite
            spriteRenderer.sprite = currentBall.happySprite;

            // setting jumpy properties
            playerMovement.acceleration = currentBall.ballAcceleration;
            playerMovement.maxJumpSpeed = currentBall.ballJumpPower;
            playerMovement.maxSpeed = currentBall.ballMaxSpeed;
        }
    }
}
