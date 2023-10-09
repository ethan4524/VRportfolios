using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    Transform spawnPoint;
    GameObject mySpawnedObject = null;

    public GameObject spawnedObjectsParent;

    private void OnEnable()
    {
        spawnPoint = this.gameObject.GetNamedChild("Object Spawn").transform;
        //SpawnObject();
    }

    public void SpawnObject()
    {
        mySpawnedObject = Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        mySpawnedObject.transform.parent = spawnedObjectsParent.transform;
    }

    public void ResetSpawn()
    {   
        if (mySpawnedObject != null)
        {
            Destroy(mySpawnedObject);
        }
        SpawnObject();
    }

    public void Reset()
    {
        if (mySpawnedObject != null)
        {
            Destroy(mySpawnedObject);
        }
    }
}
