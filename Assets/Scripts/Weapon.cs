using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;

    public float cooldownTime;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            animator.SetBool("IsShooting", true);
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
