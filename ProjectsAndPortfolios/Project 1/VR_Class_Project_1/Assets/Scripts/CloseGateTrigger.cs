using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseGateTrigger : MonoBehaviour
{
    public GameObject gateSpikes;
    bool isClosed = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (isClosed == false)
            {
                gateSpikes.GetComponent<SpawnGate>().CloseGate();
                isClosed = true;
            }
        }
    }
}
