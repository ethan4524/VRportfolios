using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLogic : MonoBehaviour
{

    [SerializeField] 
    public Camera myCamera;

    private void Awake()
    {
        myCamera.gameObject.SetActive(false);
    }

   

    public void SetState(bool _state)
    {
        myCamera.gameObject.SetActive(_state);
    }
}
