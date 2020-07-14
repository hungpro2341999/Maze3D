using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowPreviewLevelLock : Windown
   


{
    public Image PreviewImg;
    public override void Event_Open()
    {
        PreviewImg.sprite = GamePlayCtrl.Ins.Data.GetLevel(GamePlayCtrl.Ins.LevelGameCurr);
        PreviewImg.SetNativeSize();
    }

    public void Back()
    {
        GameManager.Ins.OpenWindown(TypeWindown.Select);
    }
  
}
