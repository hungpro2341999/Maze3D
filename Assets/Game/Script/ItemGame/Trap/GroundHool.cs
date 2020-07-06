using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHool : Trap
{
    public Vector3 Target;

    public Vector3 PosContinue;
   
    public override void TriggerTrap(BallControlScript ball)
    {
        if (!ball.isAutoRespawn)
        {
            ball.body.isKinematic = true;
            ball.body.velocity = Vector3.zero;
            Vector3 posRespawn = new Vector3(PosContinue.x, ball.transform.position.y, PosContinue.z);
            GamePlayCtrl.Ins.GetCurrLevel().PosContinue = posRespawn;
        }
        else
        {
            GamePlayCtrl.Ins.GetCurrLevel().PosContinue = ball.posRespawn;
        }
   
       
        ball.AnimFallHoll.SetBool("Die", true);

    }
   
  

    public void SetTarget()
    {
       // PosContinue = transform.GetChild(0).transform.position;
    }

    public override void EndTrap()
    {
        GameManager.Ins.isGameOver = true;
        GameManager.Ins.OpenWindown(TypeWindown.OverGame);
    }
 
}
