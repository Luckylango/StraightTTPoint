using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float cooldownTime = 1f;
    private bool isCooldown = false;

    public MovementType movementType;


    public enum MovementType
    {
        keyboard,
        controller
    };

    private void Update()
    {
        if (movementType == MovementType.keyboard)
        {
            if (Input.GetButtonDown("Shoot") && !isCooldown)
            {
                StartCoroutine(Cooldown());
                Shoot();
            }
        }
        else
        {
            if (movementType == MovementType.controller)
            {
                if (Input.GetButtonDown("ShootGP") && !isCooldown)
                {
                    StartCoroutine(Cooldown());
                    Shoot();
                }
            }
        }
    }

    private IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
    
