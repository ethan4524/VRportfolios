using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLogic : MonoBehaviour
{
    float rayLength = 1.0f;
    public GameObject prefab;
    Vector3 spawnLocation;
    public void UpdateRayLength(float length)
    {
        rayLength = length;
    }
    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            Transform objectHit = hit.transform;

            spawnLocation = hit.point;
            spawnLocation = new Vector3(spawnLocation.x, spawnLocation.y + 0.5f, spawnLocation.z);
            Debug.Log("Ray hit: " + objectHit.name); //portfolio 
            //Debug.Log("Ray hit: " + objectHit.name + " at point: " + hitPoint);
    
        } else
        {
            spawnLocation = Vector3.zero;
        }
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

    }

    public void SpawnObject()
    {
        if (spawnLocation == Vector3.zero)
            return;
        Destroy(Instantiate(prefab, spawnLocation, Quaternion.identity), 5);
    }
}

