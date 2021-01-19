using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject projectile;

    public Transform shotPoint;

    private float timeBetweenShots;
    private float timeBetweenShotsReset;

    void Start()
    {
        timeBetweenShotsReset = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                timeBetweenShots = timeBetweenShotsReset;
            }
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, shotPoint.position, transform.rotation);
    }
}

