using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopUpShowLevel : WindownPopUP
{
    public Text text;
    public override void Event_Open()
    {
        text.text = "LEVEL " + GamePlayCtrl.Ins.LevelGameCurr;
        base.Event_Open();
        GameManager.Ins.isGameOver = true;
       

    }
    // Start is called before the first frame update
    public override void Active()
    {
        GameManager.Ins.isGameOver = false;
        gameObject.SetActive(false);
    }
}
