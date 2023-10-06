using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketLogic : MonoBehaviour
{
    public GameObject moltenObject;

    public Transform pointA; // Starting point.
    public Transform pointB; // Ending point.
    public float duration = 2.0f; // Duration of the movement in seconds.

    private Vector3 initialPosition;
    private float startTime;
    bool isFilled = false;
    bool canSpawn;
    public Transform spawnPosition;
    public GameObject lavaParticle;
    float spawnDelay = 0.05f;
    

    bool doEffect = true;

    private void Start()
    {
        moltenObject.SetActive(false);

    }

    public void StartEffect()
    {
        // Store the initial position of the object.
        initialPosition = moltenObject.transform.position;
        moltenObject.SetActive(true);

        // Start the movement.
        StartMovement();
    }

    private void StartMovement()
    {
        // Reset the start time.
        startTime = Time.time;

        // Start the coroutine to move the object.
        StartCoroutine(MoveObjectCoroutine());
    }

    private IEnumerator MoveObjectCoroutine()
    {
        if (doEffect)
        {
            doEffect = false;
            float elapsedTime = 0.0f;

            while (elapsedTime < duration)
            {
                // Calculate the interpolation factor (0 to 1).
                float t = elapsedTime / duration;

                // Interpolate the object's position between pointA and pointB.
                moltenObject.transform.position = Vector3.Lerp(initialPosition, pointB.position, t);

                // Increment the elapsed time.
                elapsedTime += Time.deltaTime;

                // Wait for the next frame.
                yield return null;
            }

            // Ensure the object reaches pointB exactly.
            moltenObject.transform.position = pointB.position;
            isFilled = true;
            canSpawn = true;
            moltenObject.GetComponent<Collider>().enabled = false;
        }
        
    }

    // Call this method to restart the movement.
    public void RestartMovement()
    {
        // Reset the object's position to pointA.
        transform.position = initialPosition;

        // Start the movement again.
        StartMovement();
    }

    public void Update()
    {
        if (isFilled)
        {
            // Get the object's local up direction. (The bucket is -90 from default so adjust from up to forward)
            Vector3 localUp = transform.forward;

            // Get the world up direction (positive Y-axis).
            Vector3 worldUp = Vector3.up;

            // Calculate the dot product of localUp and worldUp.
            float dotProduct = Vector3.Dot(localUp, worldUp);

            // Check if the dot product is less than zero, indicating the downward hemisphere.
            if (dotProduct < 0)
            {
                //Debug.Log("Positive Y-direction is facing the downward hemisphere: " + dotProduct);
                this.gameObject.GetComponent<MeshRenderer>().materials[1].color = Color.green;
                SpawnLava();
            }
            else
            {
                //Debug.Log("NO" + dotProduct);
                this.gameObject.GetComponent<MeshRenderer>().materials[1].color = Color.red;
            }
        }
        
        

    }

    public void SpawnLava()
    {
        if (canSpawn)
        {
            canSpawn = false;
            Instantiate(lavaParticle, spawnPosition.position, Quaternion.identity);
            Invoke(nameof(ResetCanSpawnLava), spawnDelay);
        }
    }

    public void ResetCanSpawnLava()
    {
        canSpawn=true;
    }



}
