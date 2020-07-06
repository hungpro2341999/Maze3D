using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Item
{
 public enum TypeTeleport { Single , Multi};   
    public Teleport TargetPort;
    public bool Send = false;
    public TypeTeleport typeTepleport = TypeTeleport.Single;
   



    public override void ActiveItemTriger(BallControlScript ball)
    {
        if (Send)
            return;
        SendToPort(TargetPort,ball);

        
    }

    public override void ResetItem()
    {
        Send = false;
    }

    private void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += 100 * Time.deltaTime;
        transform.eulerAngles = rotation;
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
        if(typeTepleport == TypeTeleport.Single)
        {
             Port.Send = true;
             ball.transform.position =  new Vector3(Port.transform.position.x,ball.transform.position.y, Port.transform.position.z);

        }
        else
        {
            Port.Send = true;
            Port.TargetPort = this;
            ball.transform.position = new Vector3(Port.transform.position.x, ball.transform.position.y, Port.transform.position.z);
        }
    }
       
     
     
   
}
