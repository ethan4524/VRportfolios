using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAmeManager : MonoBehaviour
{
    public Transform[] spawns;
    public GameObject ball;
    public float force1;
    public float force2;
    public float force3;
    
    public void SpawnBallsLight()
    {
        foreach (Transform t in spawns)
        {
            Instantiate(ball,t).GetComponent<Rigidbody>().AddForce(Vector3.down * force1);
        }
    }
    public void SpawnBallsNormal()
    {
        foreach (Transform t in spawns)
        {
            Instantiate(ball, t).GetComponent<Rigidbody>().AddForce(Vector3.down * force2);
        }
    }
    public void SpawnBallsHard()
    {
        foreach (Transform t in spawns)
        {
            Instantiate(ball, t).GetComponent<Rigidbody>().AddForce(Vector3.down * force3);
        }
    }
}
