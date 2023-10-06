using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaParticleLogic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("LavaZone"))
        {
            Destroy(gameObject);
            
        } else if (other.gameObject.tag.Equals("CastZone"))
        {
            other.gameObject.GetComponent<SwordCast>().AddLava();
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
}
