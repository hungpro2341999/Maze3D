using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHoll : FallHool
{
    public override void TriggerTrap(BallControlScript ball)
    {
        GameManager.Ins.OpenSingleWindown(TypeWindown.PopUpWin);
        ball.Die = true;
        ball.body.isKinematic = true;
        ball.body.velocity = Vector3.zero;
        ball.AnimFallHoll.SetBool("Die", true);
        AudioCtrl.Ins.Play("Complete");

    }
    public override void EndTrap()
    {
        GameManager.Ins.isGameOver = true;
        
    }
    public override void SetTarget()
    {
        if (GetComponent<Renderer>() != null)
        {
            Target = GetComponent<Renderer>().bounds.center;
        }
        else
        {
            Target = transform.position;
        }
    }
}
