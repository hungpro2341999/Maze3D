using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Item
{

    public Teleport TargetPort;
    public bool Send = false;
    public override void ActiveItemTriger(BallControlScript ball)
    {
        //if (Send)
        //    return;
        SendToPort(TargetPort,ball);

        
    }
  

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Send = false;
        }
    }

    public void SendToPort(Teleport Port,BallControlScript ball) 
    {
        Port.Send = true;
        ball.transform.position = Port.transform.position;
    }
     
     
   
}
