using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laze :KillBall
{
    private void Start()
    {
      Vector3 scale = transform.localScale;
        scale.z = 0;

    }
    public float Target;
    public float speed;
    public override void Kill_Ball(BallControlScript ball)
    {
      
    }

    private void Update()
    {
        
    }

}
