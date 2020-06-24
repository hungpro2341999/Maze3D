using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindownOver : Windown
{ 
   public void ContinueGame()
    {
        GamePlayCtrl.Ins.ContinueLevel();
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);
    }

    public void RestGame()
    {
        GamePlayCtrl.Ins.ResetLevel();
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);

    }

    public void BackToHome()
    {
        GameManager.Ins.OpenWindown(TypeWindown.StartGame);
    }

}
