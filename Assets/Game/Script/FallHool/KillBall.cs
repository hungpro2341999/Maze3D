using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KillBall :MonoBehaviour
{

    // Start is called before the first frame update
   public virtual void Kill_Ball(BallControlScript ball)
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coll Game");
        if (other.gameObject.layer == 9)
        {
            Debug.Log("Coll : "+other.gameObject.name);
            Kill_Ball(other.transform.parent.gameObject.GetComponent<BallControlScript>());
        }   
    }
}
