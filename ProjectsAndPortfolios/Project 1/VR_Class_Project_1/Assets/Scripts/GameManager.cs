using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<ObjectSpawner> ObjectSpawns;
    private void Start()
    {
        foreach (ObjectSpawner obj in ObjectSpawns)
        {
            obj.SpawnObject();
        }
    }
}
