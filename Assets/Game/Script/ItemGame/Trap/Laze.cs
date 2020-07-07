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

    public SpriteRenderer Img;
    public Vector3 PosRespawn;
    public float DelayStart;
    public float timeDelayStart;
    public bool BallIn;
    public bool CanKill = false;


    private void Start()
    {
        PosRespawn = transform.Find("PosRespawn").position;
        GamePlayCtrl.Ins.GetCurrLevel().ResetContinueGame += ResetTrap;
    }

    public void ResetTrap()
    {
        BallIn = false;
        CanKill = false;
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
                //    GetComponent<BoxCollider>().enabled = false;
                CanKill = false;
               
            }
            else
            {
                CanKill = true;
                ShootLaze();
            }
        }

        if (BallIn)
        {
            if (CanKill)
            {
                var ball = GamePlayCtrl.Ins.GetCurrLevel().Ball;
                if (!ball.Die)
                {
                    GameManager.Ins.OpenWindown(TypeWindown.OverGame);
                    GameManager.Ins.isGameOver = true;
                    SetPosRespawn(ball);
                    ball.Die = true;
                }
               
            }
        }
    }

    public void ShootLaze()
    {
        if (timeDelayShootBack <= DelayShootBack)
        {
          //  GetComponent<BoxCollider>().enabled = true;
            Img.color = new Color(1, 1, 1, 1);
            timeDelayShootBack += Time.deltaTime;
        }
        else
        {
            time = 0;
        }
       
      

    }

    public void SetTarget()
    {
        
    }

    public override void TriggerTrap(BallControlScript ball)
    {
       
        //GameManager.Ins.OpenWindown(TypeWindown.OverGame);
        //GameManager.Ins.isGameOver = true;
        //SetPosRespawn(ball);
    }
    public override void TrapActive(BallControlScript ball)
    {
       
    }

    public void SetPosRespawn(BallControlScript ball)
    {


        if (ball.isAutoRespawn)
        {
            GamePlayCtrl.Ins.GetCurrLevel().PosContinue = ball.posRespawn;

        }
        else
        {
            PosRespawn = new Vector3(PosRespawn.x, ball.transform.position.y, PosRespawn.z);
            GamePlayCtrl.Ins.GetCurrLevel().PosContinue = PosRespawn;
        }
     
       




    }
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball1")
        {
            BallIn = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball1")
        {
            BallIn = false;
        }
    }
}
