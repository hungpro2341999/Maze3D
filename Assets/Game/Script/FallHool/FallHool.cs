using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHool : KillBall
{
    // Start is called before the first frame update
    public override void Kill_Ball(BallControlScript ball)
    {
      
        ball.Move_To_Hool(transform.position);
    }
}
