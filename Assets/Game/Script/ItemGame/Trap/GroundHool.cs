using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHool : Trap
{
    public Vector3 Target;

    public override void TriggerTrap(BallControlScript ball)
    {

        Target = ball.transform.position + ball.body.velocity.normalized*0.1f;
        ball.body.isKinematic = true;
        ball.body.velocity = Vector3.zero;


    }

    public override void TrapActive(BallControlScript ball)
    {
        ball.transform.position = Vector3.MoveTowards(new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z),
                                                  new Vector3(Target.x, ball.transform.position.y, Target.z), Time.deltaTime);
        if (Vector3.Distance(ball.transform.position, Target) == 0)
        {
            ball.AnimFallHoll.SetBool("Die", true);
        }
      
    }
    public override void EndTrap()
    {
        GameManager.Ins.isGameOver = true;
        GameManager.Ins.OpenWindown(TypeWindown.OverGame);
    }

}
