﻿using System.Collections;
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

    public SpriteRenderer Img;
    public Vector3 PosRespawn;
    public float DelayStart;
    public float timeDelayStart;
   


    private void Start()
    {
        
    }
    private void Update()
    {
        if(timeDelayStart < DelayStart)
        {
            timeDelayStart += Time.deltaTime;
            return;
        }
        if (gameObject.activeSelf)
        {
            if (time <= Delay)
            {
                timeDelayShootBack = 0;
                time += Time.deltaTime* SpeedDelay;
                Img.color = new Color(1, 1, 1, 0.5f);
                GetComponent<BoxCollider>().enabled = false;
               
            }
            else
            {
               
                ShootLaze();
            }
        }
    }

    public void ShootLaze()
    {
        if (timeDelayShootBack <= DelayShootBack)
        {
            GetComponent<BoxCollider>().enabled = true;
            Img.color = new Color(1, 1, 1, 1);
            timeDelayShootBack += Time.deltaTime;
        }
        else
        {
            time = 0;
        }
       
      

    }

    public override void TriggerTrap(BallControlScript ball)
    {
        GameManager.Ins.OpenWindown(TypeWindown.OverGame);
        GameManager.Ins.isGameOver = true;
    }
    public override void TrapActive(BallControlScript ball)
    {
       
    }

    public void SetPosRespawn(BallControlScript ball)
    {


      
        PosRespawn = new Vector3(PosRespawn.x, ball.transform.position.y, PosRespawn.z);
        GamePlayCtrl.Ins.GetCurrLevel().PosContinue = PosRespawn;




    }
}
