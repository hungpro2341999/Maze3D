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

  


    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            var ball = other.transform.parent.GetComponent<BallControlScript>();
            if (ball.Die)
            {
                return;
            }
            ActiveEffTrap(ball);
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
