using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorProjectile : MonoBehaviour
{
    public Color impactColor = Color.red; // Color to change to 

    private bool hasImpacted = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasImpacted)
        {
            GameObject hitObject = collision.gameObject;

            Renderer renderer = hitObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                
                renderer.material.color = impactColor;
            }

            hasImpacted = true;

            Destroy(gameObject);
        }
    }
}
