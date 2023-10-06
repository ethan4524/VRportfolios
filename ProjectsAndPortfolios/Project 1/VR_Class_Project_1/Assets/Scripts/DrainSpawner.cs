using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; 
    public float spawnDelay = 1.0f; // Delay between spawns in seconds.
    public float spawnDuration = 10.0f; // Total duration for spawning in seconds.

    private float spawnTimer = 0.0f;
    private float elapsedTime = 0.0f;
    private bool isSpawning = false;

    private void Start()
    {
        isSpawning = false;
    }

    public void EnableSpawning()
    {
        isSpawning = true;
    }

    public void DisableSpawning()
    {
        isSpawning = false;
    }

    private void Update()
    {
        // Check if spawning should continue.
        if (isSpawning)
        {
            elapsedTime += Time.deltaTime;

            // Check if we should stop spawning.
            if (elapsedTime >= spawnDuration)
            {
                isSpawning = false;
                return;
            }

            // Check if it's time to spawn another object.
            if (spawnTimer >= spawnDelay)
            {
                // Instantiate the object and reset the timer.
                Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                spawnTimer = 0.0f;
            }

            spawnTimer += Time.deltaTime;
        }
    }
}
