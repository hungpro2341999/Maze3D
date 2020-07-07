using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewLevel : Windown
{
    public Text text;

    public override void Event_Open()
    {
        text.text = "Level " + GamePlayCtrl.Ins.LevelGameCurr;

    }

    public void Play()
    {
          GameManager.Ins.OpenWindown(TypeWindown.GamePlay);
          GamePlayCtrl.Ins.OpenLevel(GamePlayCtrl.Ins.LevelGameCurr);
    }
    public void Back()
    {
        GameManager.Ins.OpenWindown(TypeWindown.Select);
    }
}
