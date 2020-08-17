using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnLocation;
    public float force = 1000f;

    private GameObject spawnedProjectile;
    private Rigidbody projectileRb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootThing();
        }
    }

    void ShootThing()
    {
        if(spawnedProjectile == null)
        {
            spawnedProjectile = Instantiate(projectile, spawnLocation);
            projectileRb = spawnedProjectile.GetComponent<Rigidbody>();
        }
        else
        {
            spawnedProjectile.transform.position = spawnLocation.position;
            projectileRb.velocity = Vector3.zero;
        }

        projectileRb.AddForce(spawnLocation.forward * force, ForceMode.VelocityChange);
    }
}
