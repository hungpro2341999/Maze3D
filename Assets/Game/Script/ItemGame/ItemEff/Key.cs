using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    
    Animator AnimItem;
    public bool ActiveKey = false;
    private void Start()
    {
        AnimItem = GetComponent<Animator>();
    }
   
    public override void ActiveItemTriger(BallControlScript ball)
    {
        if (ActiveKey)
            return;
        AnimItem.SetBool("Active", true);
        Debug.Log("ActiveKey");
        Lock.CountUnClockKey += 1;
        ActiveKey = true;
    }
    public override void ResetItem()
    {
        AnimItem.SetBool("Active", false);
        ActiveKey = false;

    }
}
