using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject teleportProjectile;
    public GameObject colorProjectile;
    GameObject projectile;
    public GameObject spawnPoint;
    public float blastForce;
    float fireRate = 0.5f;
    bool canFire = true;
    public enum FireType  
    {   
        Teleporter,
        ColorSwaper
    };
    public FireType fireType;
    public LayerMask impactLayer;
    private void Start()
    {
        if (fireType == FireType.Teleporter)
        {
            projectile = teleportProjectile;
        } else if (fireType == FireType.ColorSwaper)
        {
            projectile = colorProjectile;
        }
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (canFire)
            {
                canFire = false;
                Fire();
                Invoke(nameof(ResetCanFire), fireRate);
            }
        }
    }

    public void Fire()
    {
        canFire = false;
        GameObject shot = Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.localRotation);
        Vector3 shootDirection = mainCamera.transform.forward;
        shot.GetComponent<Rigidbody>().AddForce(shootDirection * blastForce);
        if (fireType == FireType.Teleporter)
        {
            Bullet impactHandler = shot.GetComponent<Bullet>();
            impactHandler.SetTeleportLayer(impactLayer);
        }
        
    }

    public void ResetCanFire()
    {
        canFire = true;
    }
}
