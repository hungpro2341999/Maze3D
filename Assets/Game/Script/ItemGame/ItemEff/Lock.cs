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
    private void Update()
    {
        if (UnClock)
            return;
        if (PreviousCountUnClockKey != CountUnClockKey)
        {
            if (CountUnClockKey >= LockKey)
            {
                UnClock = true;
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
        PreviousCountUnClockKey = 0;
        CountUnClockKey = 0;
        UnClock = false;
        CountUnClockKey = 0;
    }


}
