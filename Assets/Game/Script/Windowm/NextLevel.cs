using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : Windown
{

    public Text textStatus;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void Event_Open()
    {
        textStatus.text = "You need "+CtrlEvaluatePlayer.GetTime()+" minutes !";
    }

    public void PlayNextLevel()
    {
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);

        GamePlayCtrl.Ins.NextLevel();
    }

    public void PlayAgain()
    {
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);
        GamePlayCtrl.Ins.Play();
    }
    public void BackToHome()
    {
        GameManager.Ins.OpenWindown(TypeWindown.Select);
    }
}
