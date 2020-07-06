using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGem : Item
{
    public  int CountUnGem;
    public static int DiamondCurr;   
    public int LockKey;
   
    public bool UnClock = false;
    public Animator UnclockLock;
    public List<Diamond> Diamonds = new List<Diamond>();

   


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
        DiamondCurr = -1;
        UnclockLock.SetBool("Active", false);
        PreviousCountUnClockKey = 0;
        CountUnGem = 0;
        UnClock = false;
        
    }

  

    public void AddDiamond(Diamond diamond)
    {
        if (diamond.ActiveKey)

            return;

        if (!Diamonds.Contains(diamond))
        {
            Diamonds.Add(diamond);
            diamond.ChangeColor();
        }
        if (Diamonds.Count == 2)
        {
            
            if (Diamonds[0].id == Diamonds[1].id)
            {
                CountUnGem++;
                Diamonds[0].ActiveDiamond();
                Diamonds[1].ActiveDiamond();
                Diamonds.Clear();
            }
            else
            {
                Diamonds[0].BackToNormarl();
                Diamonds.Remove(Diamonds[0]);

            }

           



        } 
    }

    
}
