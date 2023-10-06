using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.ParticleSystemJobs;
using Unity.VisualScripting;

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

    [Header("Lever Socket")]
    public XRSocketInteractor leverSocket;

    [Header("References")]
    public GameObject flames;
    public Transform fireSpawn;
    public GameObject InteractableLever;
    public Transform LeverSpawnPoint;
    private GameObject spawnedLever = null;
    public GameObject forgeDrain;
    private GameObject bucketObject;
    GameObject metal1, metal2, metal3, coal;


    [Header("Debug Checks")]
    [SerializeField]
    private bool metalFilled = false;
    [SerializeField]
    private bool fuelFilled = false;
    [SerializeField]
    private bool bucketFilled = false;
    [SerializeField]
    private bool leverInPlace = false;

    bool canCheckLeverValue = false;
    bool forgeReady = false;

    int metalCount = 0;

    public void Update()
    {
        //check each of the sockets...
        
        FuelSocketCheck();
        MetalCheck();
        BucketSocketCheck();
        LeverSocketCheck();
        forgeReady = (metalFilled & fuelFilled & bucketFilled & leverInPlace);
        
        if (forgeReady)
        {
            //Debug.Log("FORGE IS READY TO BE LIT");
            if (canCheckLeverValue)
            {
                float leverAngle = spawnedLever.GetComponent<LeverLogic>().GetLeverValue();
                //Debug.Log("Lever Value is: " + leverAngle);
                if (leverAngle > 70f)
                {
                    //Debug.Log("LEVER ACTIVATED");
                    StartForge();
                }
            }
        }
    }

    private void Start()
    {
        if (flames != null)
            flames.SetActive(false);
    }

    public void StartForge()
    {
        //Instantiate(flames, fireSpawn.position, fireSpawn.rotation);
        flames.SetActive(true);
        forgeDrain.GetComponent<DrainSpawner>().EnableSpawning();
        if (bucketObject != null)
        {
            bucketObject.GetComponent<BucketLogic>().StartEffect();
            Invoke("DisableForge", 10.0f);
        }
        
    }

    private void DisableForge()
    {
        //disable flames
        flames.SetActive(false);

        //destroy the metal and coal
        Destroy(metal1);
        Destroy(metal2);
        Destroy(metal3);
        Destroy(coal);



    }



    public bool GetForgeIsReady()
    {
        return forgeReady;
    }

    public void MetalCheck()
    {
        if (metalCount == 3)
        {
            metalFilled = true;
            //Debug.Log("Metal is full!!");
        } else
        {
            metalFilled = false;
            //Debug.Log("Metal is at " + metalCount);
        }
        
        
    }

    public void AddMetal()
    {
        metalCount++;
        MetalSocketCheck();
    }
    public void RemoveMetal()
    {
        metalCount--;
        MetalSocketCheck();
    }

    public void MetalSocketCheck()
    {
        IXRSelectInteractable socketObject1 = metalSocket1.GetOldestInteractableSelected();
        IXRSelectInteractable socketObject2 = metalSocket2.GetOldestInteractableSelected();
        IXRSelectInteractable socketObject3 = metalSocket3.GetOldestInteractableSelected();
        if (socketObject1 != null)
        {
            metal1 = metalSocket1.GetOldestInteractableSelected().transform.gameObject;
        }
        else
        {
            metal1 = null;
        }
        if (socketObject2 != null)
        {
            metal2 = metalSocket2.GetOldestInteractableSelected().transform.gameObject;
        }
        else
        {
            metal2 = null;
        }
        if (socketObject3 != null)
        {
            metal3 = metalSocket3.GetOldestInteractableSelected().transform.gameObject;
        }
        else
        {
            metal3 = null;
        }
    }

    public void FuelSocketCheck()
    {
        IXRSelectInteractable socketObject1 = fuelSocket.GetOldestInteractableSelected();
        if (socketObject1 != null)
        {
            //Debug.Log("Something inside fuel socket");
        }
        
        if (socketObject1 != null)
        {
            fuelFilled = true;
            coal = fuelSocket.GetOldestInteractableSelected().transform.gameObject;
        }
        else
        {
            fuelFilled = false;
            coal = null;
        }
    }

    public void BucketSocketCheck()
    {
        IXRSelectInteractable socketObject1 = bucketSocket.GetOldestInteractableSelected();
        if (socketObject1 != null)
        {
            //Debug.Log("Something inside bucket socket");
        }
        
        if (socketObject1 != null)
        {
            bucketFilled = true;
            bucketObject = bucketSocket.GetOldestInteractableSelected().transform.gameObject;
        }
        else
        {
            bucketFilled = false;
            bucketObject = null;
        }
    }
    public void LeverSocketCheck()
    {
        if (leverInPlace == false)
        {
            IXRSelectInteractable socketObject1 = leverSocket.GetOldestInteractableSelected();
            if (socketObject1 != null)
            {
               // Debug.Log("Something inside lever socket");
            }
            if (socketObject1 != null)
            {
                leverInPlace = true;
                Destroy(leverSocket.GetOldestInteractableSelected().transform.gameObject);
                CreateLever();
                return;
            }
            else
            {
                leverInPlace = false;
            }
        } 
        
    }

    public void CreateLever()
    {
        leverInPlace = true;
        
        spawnedLever = Instantiate(InteractableLever, LeverSpawnPoint.position, LeverSpawnPoint.rotation);
        canCheckLeverValue = true;
    }
}
