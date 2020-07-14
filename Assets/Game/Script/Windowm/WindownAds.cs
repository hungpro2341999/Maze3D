using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindownAds : Windown
{
    public Transform[] Screen;
    public override void Event_Open()
    {
        base.Event_Open();

        if (GamePlayCtrl.Ins.GetCoins() <= 0)
        {
            Screen[0].gameObject.SetActive(false);
            Screen[1].gameObject.SetActive(true);
        }
        else
        {
            Screen[0].gameObject.SetActive(true);
            Screen[1].gameObject.SetActive(false);
        }
    }

    public void ResetLevel()
    {
        GamePlayCtrl.Ins.ResetLevel();
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);
    }

    public void Continue()
    {
        GamePlayCtrl.Ins.EarnCoins(1);
        GamePlayCtrl.Ins.ContinueLevel();
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);

    }
}
