using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    Transform spawnPoint;
    GameObject mySpawnedObject = null;

    private void OnEnable()
    {
        spawnPoint = this.gameObject.GetNamedChild("Object Spawn").transform;
        //SpawnObject();
    }

    public void SpawnObject()
    {
        mySpawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
    }

    public void ResetSpawn()
    {   if (mySpawnedObject != null)
        {
            Destroy(objectToSpawn);
        }
        SpawnObject();
    }
}
