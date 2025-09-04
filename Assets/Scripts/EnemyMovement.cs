using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float maxDistance;    // max distance enemy will move
    public float speed;    // speed by which enemy will move

    private void Start()
    {
        // starting enemy movement
        StartCoroutine(MoveCoroutine());
    }

    // main coroutine for enemy movement
    private IEnumerator MoveCoroutine()
    {
        while (true)    // infinite movement using while loop
        {
            while (Time.timeScale == 0) yield return null;    // wait till unpaused
            yield return MoveRight();    // moving right using another coroutine

            while (Time.timeScale == 0) yield return null;    // wait till unpaused
            yield return MoveLeft();    // moving left using another coroutine
        }
    }

    // left movement coroutine
    private IEnumerator MoveLeft()
    {
        float movedDistance = 0f;    // distance moved

        while (movedDistance < maxDistance)    // moving till movedDistance is less than maxDistance
        {
            while (Time.timeScale == 0) yield return null;    // wait till unpaused

            transform.Translate(Vector3.left * speed * Time.deltaTime);    // moving the enemy
            movedDistance += speed * Time.deltaTime;    // updating movedDistance
            yield return null;    // wait for next frame
        }
    }

    // right movement coroutine
    private IEnumerator MoveRight()
    {
        float movedDistance = 0f;    // distance moved

        while (movedDistance < maxDistance)    // moving till movedDistance is less than maxDistance
        {
            while (Time.timeScale == 0) yield return null;

            transform.Translate(Vector3.right * speed * Time.deltaTime);    // moving the enemy
            movedDistance += speed * Time.deltaTime;    // updating movedDistance
            yield return null;    // wait for next frame
        }
    }
}
