using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindownSelectLevel : Windown
{
    public int PageCurr;
    public int maxPageCurr;
    public List<ButtonLevel> Level;
    private void Start()
    {
        maxPageCurr = (int)(GamePlayCtrl.Ins.LevesGame.Count / 6);
        for (int i = 0; i < Level.Count; i++)
        {
            Level[i].levelSelect = i + PageCurr * 6;
            Level[i].Level.text = (i + PageCurr * 6).ToString();


        }
    }
    public void OpenLevel(int level)
    {
        GamePlayCtrl.Ins.OpenLevel(level);
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);
        
    }

    public void NextPage()
    {
        if (PageCurr >= maxPageCurr)
            return;
        PageCurr++;
        for (int i=0;i<Level.Count;i++)
        {
            Level[i].levelSelect = i + PageCurr * 6;
            Level[i].Level.text = (i + PageCurr * 6).ToString();


        }
    }

    public void PreviousPage()
    {
        if (PageCurr <= 0)
        {
            return;
        }
        PageCurr--;
        for (int i = 0; i < Level.Count; i++)
        {
            Level[i].levelSelect = i + PageCurr * 6;
            Level[i].Level.text = (i + PageCurr * 6).ToString();


        }
    }

  
}
