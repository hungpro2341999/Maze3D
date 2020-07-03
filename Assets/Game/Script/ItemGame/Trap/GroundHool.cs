using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHool : Trap
{
    public Vector3 Target;

    public Vector3 PosContinue;
    public override void AddTrap(BallControlScript ball)
    {
      
    }
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
   
    public override void TrapActive(BallControlScript ball)
    {
      
       
           
       
      
    }

    public void SetTarget()
    {
        PosContinue = transform.GetChild(0).transform.position;
    }

    public override void EndTrap()
    {
        GameManager.Ins.isGameOver = true;
        GameManager.Ins.OpenWindown(TypeWindown.OverGame);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Add_Trap_When_Out(other.transform.parent.GetComponent<BallControlScript>());
        }
    }

    public void Add_Trap_When_Out(BallControlScript ball)
    {
        ball.AddOnActionDie(TriggerTrap, TrapActive, EndTrap, timeEnd);
    }
}
