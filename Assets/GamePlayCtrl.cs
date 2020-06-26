using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayCtrl : MonoBehaviour
{
    

    public List<Level> LevesGame = new List<Level>();

    public static GamePlayCtrl Ins;

    public static int LevelGameCurr;

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
        
        LevelGameCurr = levelMaze;

        Debug.Log("Open");
        foreach(var level in LevesGame)
        {
            if(level.level == levelMaze)
            {
                level.StartLevel();
            }
        }

        GameManager.Ins.isGameOver = false;
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

}


