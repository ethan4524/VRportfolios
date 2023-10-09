using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : MonoBehaviour
{
    public Camera mapCamera;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("player"))
        {
            mapCamera.enabled = true;
        } else
        {
            mapCamera.enabled = false;
        }
    }
}
