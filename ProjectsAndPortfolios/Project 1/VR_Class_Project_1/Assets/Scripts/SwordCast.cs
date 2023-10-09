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

    public GameManager gameManager;
    
    public void AddLava()
    {
        numberOfLavasAdded++;
        if (numberOfLavasAdded >= 100 && isSpawned == false)
        {
            SpawnSword();
        }
    }

    public void SpawnSword()
    {
        isSpawned = true;
        GameObject newSword = Instantiate(swordPrefab, spawnLocation.position, spawnLocation.rotation);
        newSword.gameObject.transform.parent = gameManager.transform;
        gameManager.SetSword(newSword);
    }

    public void Reset()
    {
        numberOfLavasAdded = 0;
        isSpawned = false;

    }

}
