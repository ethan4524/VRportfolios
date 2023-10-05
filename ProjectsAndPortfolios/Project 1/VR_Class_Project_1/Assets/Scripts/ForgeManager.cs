using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.ParticleSystemJobs;

public class ForgeManager : MonoBehaviour
{
    [SerializeField]
    [Header("Metal Sockets:")]
    public XRSocketInteractor metalSocket1;
    public XRSocketInteractor metalSocket2;
    public XRSocketInteractor metalSocket3;

    [Header("Fuel Sockets:")]
    public XRSocketInteractor fuelSocket;

    [Header("Bucket Sockets:")]
    public XRSocketInteractor bucketSocket;

    [Header("Cast Sockets:")]
    public XRSocketInteractor castSocket;

    [Header("Lever Socket")]
    public XRSocketInteractor leverSocket;

    public GameObject flames;

    [Header("Debug Checks")]
    [SerializeField]
    private bool metalFilled = false;
    [SerializeField]
    private bool fuelFilled = false;
    [SerializeField]
    private bool bucketFilled = false;
    [SerializeField]
    private bool castFilled = false;
    [SerializeField]
    private bool leverInPlace = false;



    private void Start()
    {
        if (flames != null)
            flames.SetActive(false);
    }


    public bool GetIsFilled()
    {
        return metalFilled;
    }

    public void MetalSocketCheck()
    {
        IXRSelectInteractable socketObject1 = metalSocket1.GetOldestInteractableSelected();
        IXRSelectInteractable socketObject2 = metalSocket3.GetOldestInteractableSelected();
        IXRSelectInteractable socketObject3 = metalSocket3.GetOldestInteractableSelected();
        if (socketObject1 != null)
        {
            Debug.Log("Something inside socket 1");
        }
        if (socketObject2 != null)
        {
            Debug.Log("Something inside socket 2");
        }
        if (socketObject3 != null)
        {
            Debug.Log("Something inside socket 3");
        }
        if (socketObject1 != null && socketObject2 != null && socketObject3 != null)
        {
            metalFilled = true;
        }
    }

    public void FuelSocketCheck()
    {
        IXRSelectInteractable socketObject1 = fuelSocket.GetOldestInteractableSelected();
        if (socketObject1 != null)
        {
            Debug.Log("Something inside fuel socket");
        }
        fuelFilled = fuelSocket != null;
    }

    public void BucketSocketCheck()
    {
        IXRSelectInteractable socketObject1 = bucketSocket.GetOldestInteractableSelected();
        if (socketObject1 != null)
        {
            Debug.Log("Something inside bucket socket");
        }
        bucketFilled = bucketSocket != null;
    }

    public void CastSocketCheck()
    {
        IXRSelectInteractable socketObject1 = castSocket.GetOldestInteractableSelected();
        if (socketObject1 != null)
        {
            Debug.Log("Something inside cast socket");
        }
        castFilled = castSocket != null;
    }

    public void LeverSocketCheck()
    {
        IXRSelectInteractable socketObject1 = leverSocket.GetOldestInteractableSelected();
        if (socketObject1 != null)
        {
            Debug.Log("Something inside lever socket");
        }
        leverInPlace = leverSocket != null;
    }
}
