using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGem : Item
{
    public static int CountUnGem;

    public int LockKey;

    public bool UnClock = false;
    public Animator UnclockLock;

    


    private int PreviousCountUnClockKey = 0;
    public virtual void Update()
    {
        if (UnClock)
            return;
        if (PreviousCountUnClockKey != CountUnGem)
        {
            if (CountUnGem >= LockKey)
            {
                UnClock = true;
                UnclockLock.SetBool("Active", true);
            }
        }
        PreviousCountUnClockKey = CountUnGem;
    }
    public void Start()
    {

    }
    public override void ResetItem()
    {
        UnclockLock.SetBool("Active", false);
        PreviousCountUnClockKey = 0;
        CountUnGem = 0;
        UnClock = false;
        
    }
}
