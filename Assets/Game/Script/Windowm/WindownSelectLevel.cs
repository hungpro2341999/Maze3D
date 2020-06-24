using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindownSelectLevel : Windown
{

    public void OpenLevel(int level)
    {
        GamePlayCtrl.Ins.OpenLevel(level);
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);
        
    }

  
}
