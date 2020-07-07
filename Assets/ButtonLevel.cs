using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevel : MonoBehaviour
{
    public int levelSelect;
    public Text Level;

    public void Play()
    {
        GamePlayCtrl.Ins.LevelGameCurr = levelSelect;
        GameManager.Ins.OpenWindown(TypeWindown.PreviewLevel);
        //  GamePlayCtrl.Ins.OpenLevel(levelSelect);
      
    }
}
