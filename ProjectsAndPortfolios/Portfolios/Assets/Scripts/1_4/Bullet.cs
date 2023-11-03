using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private LayerMask teleportLayer;

    public void SetTeleportLayer(LayerMask layer)
    {
        teleportLayer = layer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((teleportLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            // Teleport the player to the point of impact.
            TeleportPlayer(collision.contacts[0].point);
        } else
        {
            Destroy(this);
        }

        // Destroy the projectile.
        
    }

    private void TeleportPlayer(Vector3 targetPosition)
    {
       
        // Teleport the player to the target position.
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player != null)
        {           
            CharacterController cc = player.GetComponent<CharacterController>();
            cc.enabled = false;
            player.transform.position = new Vector3(targetPosition.x,targetPosition.y +1f,targetPosition.z);
            cc.enabled = true;
            Debug.Log("Teleporting Player!!! " + targetPosition);
        }
        Destroy(gameObject);
    }
}

