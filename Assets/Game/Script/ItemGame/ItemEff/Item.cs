using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
          
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
           
            ActiveItemTriger(other.gameObject.GetComponent<BallControlScript>());
        }
    }
 
  

    public virtual void ResetItem()
    {

    }
    public virtual void ActiveItemTriger(BallControlScript ball)
    {

    }



}
