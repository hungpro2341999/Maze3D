using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTick : MonoBehaviour
{
    public List<Tick> Ticks = new List<Tick>();

    private void Start()
    {
        TypeSpeed type = GamePlayCtrl.Ins.GetTypeSpeed(GamePlayCtrl.Ins.GetTypeSpeedInt());
        foreach (var a in Ticks)
        {
            if(a.typeSpeed == type)
            {
                a.CheckTick(true);
            }
            else
            {
                a.CheckTick(false);
            }
        }
          
    }
    public void Open(Tick tick)
    {
        foreach(var a in Ticks)
        {
            if(a.typeSpeed == tick.typeSpeed)
            {
                a.CheckTick(true);
            }
            else
            {
                a.CheckTick(false);
            }
        }
    }
 
}
