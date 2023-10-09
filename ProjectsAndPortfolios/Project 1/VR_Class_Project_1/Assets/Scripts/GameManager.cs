using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using UnityEngine.XR.Interaction.Toolkit;

public class GameManager : MonoBehaviour
{
    public List<ObjectSpawner> ObjectSpawns;
    public Transform playerSpawn;
    public GameObject player;
    public Bridge bridge;
    public GameObject sword;
    public SwordCast cast;
    public SpawnGate gate;
    public XRSocketInteractor swordSocket;
    public Transform spawnedObjectsParent;
    public GameObject swordObject;
    public GameObject WinMessage;
    bool swordInSlot = false;

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (swordInSlot == false)
        {
            SwordSocketCheck();
        }
        
    }

    public void StartGame()
    {
        WinMessage.SetActive(false);
        swordInSlot = false;
        gate.Reset();
        RemoveSword();
        bridge.StartRotationTo90();
        cast.Reset();
        RemoveSpawnedObjects();

        SpawnObjects();
        SpawnPlayer();       
        
    }


    public void WinGame()
    {
        if (swordInSlot)
        {
            gate.OpenGate();
            WinMessage.SetActive(true);
        }
        
    }

    public void SwordSocketCheck()
    {
        IXRSelectInteractable swordInSocket = swordSocket.GetOldestInteractableSelected();
        
        if (swordInSocket != null)
        {
            swordObject = swordSocket.GetOldestInteractableSelected().transform.gameObject;
            swordInSlot = true;
            WinGame();
        }
    }

        public void SpawnPlayer()
    {
        player.transform.position = playerSpawn.position;
        player.transform.rotation = playerSpawn.rotation;
    }

    public void SpawnObjects()
    {
        foreach (ObjectSpawner obj in ObjectSpawns)
        {
            obj.SpawnObject();
        }
    }

    public void SetSword(GameObject _sword)
    {
        sword = _sword;
    }

    public void RemoveSword()
    {
        if (sword != null)
        {
            Destroy(sword.gameObject);
        }
    }

    public void RemoveSpawnedObjects()
    {
        foreach (Transform child in spawnedObjectsParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void RestartGame()
    {
        StartGame();
    }
    public void ResetTask()
    {
        WinMessage.SetActive(false);
        swordObject = null;
        gate.Reset();
        RemoveSpawnedObjects();      
        RemoveSword();
        cast.Reset();
        SpawnObjects();

    }
}
