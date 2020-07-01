using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGround : MonoBehaviour
{

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            var a = other.transform.parent.gameObject.GetComponent<BallControlScript>();
        
        
            a.moveSpeedModifier +=1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            var a = other.transform.parent.gameObject.GetComponent<BallControlScript>();


            a.moveSpeedModifier -= 1;

        }
    }
}
