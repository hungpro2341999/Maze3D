using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    public float timeEnd;
    public void ActiveEffTrap(BallControlScript ball)
    {
        AddTrap(ball);
    }
     
    public virtual void TrapActive(BallControlScript ball)
    {
    
    }

    public virtual void TriggerTrap(BallControlScript ball)
    {

    }

    public virtual void EndTrap()
    {

    }
    public virtual void AddTrap(BallControlScript ball)
    {
        ball.AddOnActionDie(TriggerTrap,TrapActive, EndTrap,timeEnd);
    }

  


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            ActiveEffTrap(other.transform.parent.GetComponent<BallControlScript>());
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
