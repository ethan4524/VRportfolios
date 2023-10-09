using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public Transform playerHead;
    
    public CapsuleCollider myColldier;

    public float maxHeight = 2f;
    public float minHeight = 0.5f;

    private void FixedUpdate()
    {
        myColldier.height = Mathf.Clamp(playerHead.localPosition.y, minHeight, maxHeight);
        myColldier.center = new Vector3(playerHead.localPosition.x,myColldier.height/2, playerHead.localPosition.z);
        
    }
}
