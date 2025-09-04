using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public int acceleration;
    public int maxSpeed;
    public int maxJumpSpeed;
    public float jumpDuration;

    private bool isGrounded;
    private Vector2 moveInput;

    private void FixedUpdate()
    {
        float horizontalInput = moveInput.x;
        body.AddForce(acceleration * horizontalInput * Vector2.right);

        // limit the horizontal velocity to maxSpeed
        if (body.linearVelocity.x > maxSpeed)
        {
            body.linearVelocity = new Vector2(maxSpeed, body.linearVelocity.y);
        }
        else if (body.linearVelocity.x < -maxSpeed)
        {
            body.linearVelocity = new Vector2(-maxSpeed, body.linearVelocity.y);
        }
    }

    public void JumpPerformed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isGrounded)    // if grounded
            {
                StartCoroutine(Jump(maxJumpSpeed));
                isGrounded = false;    // setting isGrounded to false when jumping starts
            }
        }
    }

    public void MovementPerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    // setting isGrounded to true if player touches ground/platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")
            || collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isGrounded = true;
        }
    }

    // making sure isGrounded is false if player leaves ground/platform
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground")
            || collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            isGrounded = false;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
    //    {
    //        // entering water
    //        body.gravityScale = 3f;
    //        acceleration = 15;
    //        maxJumpSpeed = 15;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
    //    {
    //        // exiting water
    //        print("exiting water");
    //    }
    //}


    // method to make the player jump forcefully regardless of it is on the ground or not
    public void ForceJump(int maxJumpSpeed)
    {
        StartCoroutine(Jump(maxJumpSpeed));
    }

    // using Jump coroutine for continuously setting the velocity of the ball jump duration is achieved
    private IEnumerator Jump(int maxJumpSpeed)
    {
        float elapsedTime = 0f;
        while (elapsedTime < jumpDuration)
        {
            float currentVelocity = maxJumpSpeed * (elapsedTime / jumpDuration);
            body.linearVelocity = new Vector2(body.linearVelocity.x, currentVelocity);
            elapsedTime += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
