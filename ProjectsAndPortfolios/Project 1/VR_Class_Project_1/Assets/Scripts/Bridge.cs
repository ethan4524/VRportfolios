using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private float duration = 5.0f; // Duration of the rotation in seconds.
    private float elapsedTime = 0.0f;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private bool isRotating = false;

    private void Start()
    {
        // Define the start and end rotations.
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(0f, 0f, 0f); // Rotate to 0 degrees on the X-axis.
    }

    private void Update()
    {
        if (isRotating)
        {
            // Increment the elapsed time.
            elapsedTime += Time.deltaTime;

            // Calculate the interpolation factor (0 to 1) based on elapsed time and duration.
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Interpolate between start and end rotations.
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);

            // Check if the rotation has reached its end state.
            if (t >= 1.0f)
            {
                // Stop the rotation.
                isRotating = false;
            }
        }
    }

    public void StartRotationTo90()
    {
        // Start the rotation to 90 degrees when this method is called.
        startRotation = transform.rotation; // Update the start rotation.
        endRotation = Quaternion.Euler(90f, 0f, 0f); // Rotate to 90 degrees on the X-axis.
        elapsedTime = 0.0f; // Reset elapsed time.
        isRotating = true;
    }

    public void StartRotationTo0()
    {
        // Start the rotation to 0 degrees when this method is called.
        startRotation = transform.rotation; // Update the start rotation.
        endRotation = Quaternion.Euler(0f, 0f, 0f); // Rotate to 0 degrees on the X-axis.
        elapsedTime = 0.0f; // Reset elapsed time.
        isRotating = true;
    }
}
