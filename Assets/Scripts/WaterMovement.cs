using System.Collections;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float maxDistance = 1f;
    public float speed = 1f;

    private void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            while (Time.timeScale == 0) yield return null;    // wait till unpaused
            yield return MoveDown();

            while (Time.timeScale == 0) yield return null;    // wait till unpaused
            yield return MoveUp();
        }
    }

    private IEnumerator MoveUp()
    {
        float movedDistance = 0f;
        while (movedDistance < maxDistance)
        {
            while (Time.timeScale == 0) yield return null;    // wait till unpaused

            transform.Translate(Vector3.up * speed * Time.deltaTime);
            movedDistance += speed * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator MoveDown()
    {
        float movedDistance = 0f;

        while (movedDistance < maxDistance)
        {
            while (Time.timeScale == 0) yield return null;    // wait till unpaused

            transform.Translate(Vector3.down * speed * Time.deltaTime);
            movedDistance += speed * Time.deltaTime;
            yield return null;
        }
    }
}
