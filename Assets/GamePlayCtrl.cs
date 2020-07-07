using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrl : MonoBehaviour
{
    

    public List<Level> LevesGame = new List<Level>();

    public static GamePlayCtrl Ins;

    public int LevelGameCurr;

    private void Awake()
    {
        if (Ins != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Ins = this;
        }

       
    }

    public void OpenLevel(int levelMaze)
    {
        Debug.Log("Opne Level : "+levelMaze);

        LevelGameCurr = levelMaze;
       
        foreach(var level in LevesGame)
        {
            if(level.level == levelMaze)
            {
                level.StartLevel();
            }
            else
            {
                level.gameObject.SetActive(false);
            }
        }

        GameManager.Ins.OpenSingleWindown(TypeWindown.PopUpLevel);
    }

    public void ContinueLevel()
    {
                Level level = GetCurrLevel();
                level.ContinueLevel();
           
       

              GameManager.Ins.isGameOver = false;
    }

    public void ResetLevel()
    {

        foreach (var level in LevesGame)
        {
            if (level.level == LevelGameCurr)
            {
                level.ResetLevel();
            }
        }
    }

    public void NextLevel()
    {
        LevelGameCurr+=1;
        OpenLevel(LevelGameCurr);




    }
    
    public void Play()
    {
        GameManager.Ins.OpenWindown(TypeWindown.GamePlay);
        OpenLevel(LevelGameCurr);
    }
    public Level GetCurrLevel()
    {
         foreach (var level in LevesGame)
        {
            if (level.gameObject.activeSelf)
            {
                return level;
            }
        }
        Debug.Log("Not level Visible");
        return null;
    }
   public void BakeLight()
    {
        int x = 10;
        int y = 0;
        for(int i = 0; i < LevesGame.Count; i++)
        {
            if (i % 10 == 0)
            {
                y += 20;

            }
            float posx = x * i;

            LevesGame[i].transform.position = new Vector3(posx, LevesGame[i].transform.position.y, y);
        }
    }
}


