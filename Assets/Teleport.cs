using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Item
{

    public Teleport TargetPort;
    public bool Send = false;
    public override void ActiveItemTriger(BallControlScript ball)
    {
        if (Send)
            return;
        SendToPort(TargetPort,ball);

        
    }
  

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Send = false;
        }
    }

    public void SendToPort(Teleport Port,BallControlScript ball) 
    {
        Port.Send = true;
        ball.transform.position =  new Vector3(Port.transform.position.x,ball.transform.position.y, Port.transform.position.z);
    }
     
     
   
}
