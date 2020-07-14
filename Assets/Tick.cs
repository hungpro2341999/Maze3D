using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick : MonoBehaviour
{
    public Transform Check;
    public int TypeSpeed;
    public TypeSpeed typeSpeed;
    
    public void CheckTick(bool active)
    {
        Check.gameObject.SetActive(active);
        if (active)
        {
            GamePlayCtrl.Ins.SetTypeSpeed(typeSpeed);
        }
     
    }

   

}
