using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindownOver : Windown
{ 
   public void ContinueGame()
    {
        GameManager.Ins.OpenWindown(TypeWindown.WindowAds);
    }

   

    public void BackToHome()
    {
        GameManager.Ins.OpenWindown(TypeWindown.Select);
    }

}
