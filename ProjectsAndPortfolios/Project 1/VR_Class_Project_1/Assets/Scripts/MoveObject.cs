using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public Transform pointA; // The starting point.
    public Transform pointB; // The ending point.
    public float duration = 2.0f; // Duration of each movement in seconds.

    private bool isMovingToB = true;
    private float elapsedTime = 0.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private void Start()
    {
        // Initialize the starting position and end position.
        startPosition = pointA.position;
        endPosition = pointB.position;

        
    }

    private void Update()
    {
        if (isMovingToB)
        {
            // Increment the elapsed time.
            elapsedTime += Time.deltaTime;

            // Calculate the interpolation factor (0 to 1) based on elapsed time and duration.
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Interpolate between start and end positions.
            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            // Check if the movement has reached its end state.
            if (t >= 1.0f)
            {
                // Switch to moving back to point A.
                isMovingToB = false;
                SwapPositions();
            }
        }
    }

    // Function to start moving from point A to point B.
    public void MoveToB()
    {
        isMovingToB = true;
        elapsedTime = 0.0f;
    }

    // Function to start moving from point B to point A.
    public void MoveToA()
    {
        isMovingToB = false;
        SwapPositions();
        elapsedTime = 0.0f;
    }

    // Swap the start and end positions for the opposite movement.
    private void SwapPositions()
    {
        Vector3 temp = startPosition;
        startPosition = endPosition;
        endPosition = temp;
    }


}
