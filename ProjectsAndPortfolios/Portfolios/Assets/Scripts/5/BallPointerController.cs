using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPointerController : MonoBehaviour
{
    private Camera mainCamera;
    bool enableControl = false;
    

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Cast a ray from the mouse position into the scene
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Ball"))
                {
                    // Handle the click on the ball
                    GameObject ball = hit.collider.gameObject;

                    // Add your custom logic here, for example, destroying the ball
                    BallAction(ball);
                }
            }
        }
    }

    public void BallAction(GameObject _object)
    {
        if (!enableControl)
        {
            Destroy(_object);
        }
    }

    
}
