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
        maxPageCurr = (int)(GamePlayCtrl.Ins.LevesGame.Count / 9);
        for (int i = 0; i < Level.Count; i++)
        {
            Level[i].levelSelect = (i + PageCurr * 9)+1;
            Level[i].Level.text = ((i + PageCurr * 9)+1).ToString();


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
        int countLevel = GamePlayCtrl.Ins.LevesGame.Count;
        PageCurr++;
        for (int i=0;i<Level.Count;i++)
        {
           if(((i + PageCurr * 9) + 1) > countLevel+1)
            {
                Level[i].gameObject.SetActive(false);
            }
            else
            {
                Level[i].gameObject.SetActive(true);
                Level[i].levelSelect = i + PageCurr * 9;
                Level[i].Level.text = (i + PageCurr * 9).ToString();
            }
          


        }
    }

    public void PreviousPage()
    {
        if (PageCurr <= 0)
        {
            return;
        }
        PageCurr--;
        int countLevel = GamePlayCtrl.Ins.LevesGame.Count;
       // PageCurr++;
        for (int i = 0; i < Level.Count; i++)
        {
            if (((i + PageCurr * 9) + 1) > countLevel)
            {
                Level[i].gameObject.SetActive(false);
            }
            else
            {
                Level[i].gameObject.SetActive(true);
                Level[i].levelSelect = i + PageCurr * 9;
                Level[i].Level.text = (i + PageCurr * 9).ToString();
            }


        }
    }

  
}
