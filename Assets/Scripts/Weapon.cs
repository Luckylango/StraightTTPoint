using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float cooldownTime = 1f;
    private bool isCooldown = false;

    public AudioSource source;
    public AudioClip clip;

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
                source.PlayOneShot(clip, 1);
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
                    source.PlayOneShot(clip, 1);
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
    
