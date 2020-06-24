using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : Windown
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayNextLevel()
    {
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);
    
        GamePlayCtrl.Ins.OpenLevel(GamePlayCtrl.LevelGameCurr++);
    }
    public void BackToHome()
    {
        GameManager.Ins.OpenWindown(TypeWindown.StartGame);
    }
}
