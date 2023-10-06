using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCast : MonoBehaviour
{
    [SerializeField]
    private int numberOfLavasAdded;

    [Header("SwordSpawning")]
    public GameObject swordPrefab;
    public Transform spawnLocation;
    bool isSpawned = false;

    public void AddLava()
    {
        numberOfLavasAdded++;
        if (numberOfLavasAdded >= 100 && isSpawned == false)
        {
            isSpawned = true;
            Instantiate(swordPrefab, spawnLocation.position, spawnLocation.rotation);
            
        }
    }

    private void Start()
    {
        Instantiate(swordPrefab, spawnLocation.position, spawnLocation.rotation);
        Destroy(gameObject);
    }

}
