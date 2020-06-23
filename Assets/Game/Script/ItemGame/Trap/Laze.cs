using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laze : Trap
{
    public float LengthLaze;
    public float Delay;
    public float SpeedDelay;
    public float SpeedLaze;

    private float time;
    private float timeDelayShootBack;

    public bool ShootBack;
    public bool ShootForWard;

    public float DelayShootBack;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (gameObject.activeSelf)
        {
            if (time <= Delay)
            {
                time += Time.deltaTime* SpeedDelay;
                if(time <= Delay)
                {
                    ShootForWard = true;
                }
            }
            else
            {

                ShootLaze();
            }
        }
    }

    public void ShootLaze()
    {
        if (ShootForWard)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.MoveTowards(localScale.x, LengthLaze, Time.deltaTime * SpeedLaze);
            transform.localScale = localScale;
            if (timeDelayShootBack <= DelayShootBack)
            {
             
                timeDelayShootBack += Time.deltaTime;
            }
            else
            {
                if (localScale.x == LengthLaze)
                {
                    ShootForWard = false;
                }
            }
         


        }
        else
        {
            Vector3 localScale = transform.localScale;
            localScale.x = Mathf.MoveTowards(localScale.x, 0, Time.deltaTime * SpeedLaze);
            transform.localScale = localScale;

            if (transform.localScale.x == 0)
            {
                timeDelayShootBack = 0;
                   time = 0;
            }
            // CompleteLaze


      
        }
       
    }

    public override void TrapActive(BallControlScript ball)
    {
        Debug.Log("GameOver");
    }
}
