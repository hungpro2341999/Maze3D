using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHool : Trap
{
    private const float speed = 1;
    public override void TrapActive(BallControlScript ball)
    {
        
        Vector3 postion = ball.transform.position;

        ball.transform.position = Vector3.MoveTowards(new Vector3(ball.transform.position.x,ball.transform.position.y,ball.transform.position.z), 
                                                      new Vector3(transform.position.x, ball.transform.position.y, transform.position.z), Time.deltaTime);
         if(Vector3.Distance(ball.transform.position,new Vector3(transform.position.x,ball.transform.position.y, transform.position.z)) == 0)
        {
            ball.AnimFallHoll.SetBool("Die", true);
        }

        

    }

    public override void TriggerTrap(BallControlScript ball)
    {
        ball.body.isKinematic = true;
        ball.body.velocity = Vector3.zero;
    }




    public override void EndTrap()
    {
        Debug.Log("OverGame");
    }





}
