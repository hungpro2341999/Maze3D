using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Item
{
    
   public  Animator AnimItem;
    public bool ActiveKey = false;
    private void Start()
    {
        if (AnimItem==null)
            AnimItem = GetComponent<Animator>();
    }
   
    public override void ActiveItemTriger(BallControlScript ball)
    {
        if (ActiveKey)
            return;
        AudioCtrl.Ins.Play("Key");
        AnimItem.SetBool("Active", true);
        Debug.Log("ActiveKey");
        Lock.CountUnClockKey += 1;
        ActiveKey = true;
    }
    public override void ResetItem()
    {
        Debug.Log(gameObject.name);
        if (AnimItem == null)
            AnimItem = GetComponent<Animator>();
        AnimItem.SetBool("Active", false);
        ActiveKey = false;

    }
}
