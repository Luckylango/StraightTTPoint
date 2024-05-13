using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{

    private float Speed;
    private bool RestoreTime;

    public GameObject ImpactEffect;
    private Animator Anim;

    // Start is called before the first frame update
    private void Start()
    {
        RestoreTime = false;
        Anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (RestoreTime)
        {
            if (Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * Speed;
            }
            else
            {
                Time.timeScale = 1f;
                RestoreTime = false;
                //Anim.SetBool("Damaged", false);
            }
        }
    }
    
    public void StopTime(float ChangeTime, int RestoreSpeed, float Delay)
    { 
        Speed = RestoreSpeed;

        if (Delay > 0)
        {
            StopCoroutine(StartTimeAgain(Delay));
            StartCoroutine(StartTimeAgain(Delay));
        }
        else
        {
            RestoreTime = true;
        }

        Instantiate(ImpactEffect, this.gameObject.transform.position, Quaternion.identity);
        //Anim.SetBool("Damaged", true);


        Time.timeScale = ChangeTime;
    }
    
    IEnumerator StartTimeAgain(float amt)
    {
        RestoreTime = true;
        yield return new WaitForSecondsRealtime(amt);
    }
    
}
