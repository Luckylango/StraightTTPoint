using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public enum MovementType
    {
        keyboard,
        controller
    };

    public MovementType movementType;

    public float cooldownTime;

    private void Update()
    {
        if (movementType == MovementType.keyboard)
        {
            if (Input.GetButtonDown("Shoot"))
            {
                Shoot();
            }
        }
        else
        {
            if (movementType == MovementType.controller)
            {
                if (Input.GetButtonDown("ShootGP"))
                {
                    Shoot();
                }
            }
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
    
