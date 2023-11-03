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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Ball"))
                {
                    GameObject ball = hit.collider.gameObject;

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
