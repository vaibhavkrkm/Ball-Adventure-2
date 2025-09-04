using System;
using System.Collections.Specialized;
using UnityEngine;

public class SpikeFallScript : MonoBehaviour
{
    public float spikeFallRate;           // Time to complete the spike fall
    public float spikeWaitTimeOnGround;   // Time to wait on the ground after the fall on ground
    public float spikeWaitTimeOnCeiling;  // Time to wait on the ceiling before falling
    public float fallDistance;            // Distance the spike falls
    public float initialDelay;            // Initial delay before starting the drop cycles
    private Vector2 initialSpikePos;      // Store the initial position of the spike
    private bool isFalling = false;       // Flag to manage falling state
    private float spikeFallTimer = 0f;    // Timer to manage delay between cycles
    private bool dropCycleStarted = false; // Flag to know if the drop cycle has been started
    private float dropCycleTimer = 0f;

    private void Start()
    {
        initialSpikePos = transform.position;  // Save the initial position
    }

    private void Update()
    {
        if (dropCycleTimer < initialDelay && !dropCycleStarted)
        {
            dropCycleTimer += Time.deltaTime;
        }
        else
        {
            dropCycleStarted = true;
            dropCycleTimer = 0f;
        }

        if (!isFalling && dropCycleStarted)
        {
            // If not falling, start the fall after the delay
            if (spikeFallTimer < spikeFallRate)
            {
                spikeFallTimer += Time.deltaTime;
            }
            else
            {
                StartSpikeFall();    // Start falling when timer exceeds spikeFallRate
                spikeFallTimer = 0f;    // Reset the timer for the next cycle
            }
        }
    }

    void StartSpikeFall()
    {
        isFalling = true;

        // Move the spike down over half of the spikeFallRate duration
        LeanTween.delayedCall(spikeWaitTimeOnCeiling, () =>
        {
            LeanTween.moveY(gameObject, initialSpikePos.y - fallDistance, spikeFallRate)
            .setOnComplete(() =>
            {
                // Once the spike finishes falling, reset its position after a delay
                LeanTween.delayedCall(spikeWaitTimeOnGround, () =>
                {
                    transform.position = initialSpikePos;  // Reset position
                    isFalling = false;                     // Allow the next fall cycle
                });
            });
        });
    }
}
