using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Item
{ 
    public static int CountUnClockKey;
    
    public int LockKey;

    public bool UnClock = false;
    public Animator UnclockLock;


    private int PreviousCountUnClockKey = 0;
    public virtual void Update()
    {
        if (UnClock)
            return;
        if (PreviousCountUnClockKey != CountUnClockKey)
        {
            if (CountUnClockKey >= LockKey)
            {
                UnClock = true;
                AudioCtrl.Ins.Play("UnLock");
                UnclockLock.SetBool("Active", true);
            }
        }
        PreviousCountUnClockKey = CountUnClockKey;
    }
    public void Start()
    {
        
    }
    public override void ResetItem()
    {
        UnclockLock.SetBool("Active", false);
        transform.localScale = Vector3.one;
        PreviousCountUnClockKey = 0;
        CountUnClockKey = 0;
        UnClock = false;
        CountUnClockKey = 0;
    }


}
