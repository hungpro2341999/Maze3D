using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum TypeSpeed { Slow, Normal, Fast };
public class GamePlayCtrl : MonoBehaviour
{
   
    public TypeSpeed typeSpeed = TypeSpeed.Slow;

    public static float SpeedCurrBall = 0.2f;
    public DataImg Data;
    public List<Level> LevesGame = new List<Level>();

    public static GamePlayCtrl Ins;

    public int LevelGameCurr;
    public int start = 0;
    public Text text_Coins;

    public const string Key_Coin = "Key_Coins";
    public const string Key_Type_Speed = "Key_Type_Speed";
    public const string Key_Infor_Stage_Levels = "Key_Infor_Stage_Levels";


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

        Init();
       
    }
    private void Start()
    {
       // select(start);


    }
    public void Init()
    {
        if(PlayerPrefs.HasKey(Key_Coin))
        {
            text_Coins.text = PlayerPrefs.GetInt(Key_Coin).ToString();
        }
        else
        {
            PlayerPrefs.SetInt(Key_Coin, 9999);
            PlayerPrefs.Save();
            text_Coins.text = 9999.ToString();
        }

        if (PlayerPrefs.HasKey(Key_Type_Speed))
        {

            
        }
        else
        {


        }
    }

    public void AddCoins(int coins)
    {
        int coin = PlayerPrefs.GetInt(Key_Coin) + coins;
        PlayerPrefs.SetInt(Key_Coin, coin);
        PlayerPrefs.Save();
        text_Coins.text = PlayerPrefs.GetInt(Key_Coin).ToString();

    }
    public void EarnCoins(int coins)
    {
        int coin = PlayerPrefs.GetInt(Key_Coin) - coins;
        PlayerPrefs.SetInt(Key_Coin, coin);
        PlayerPrefs.Save();
        text_Coins.text = PlayerPrefs.GetInt(Key_Coin).ToString();
    }



    public void select(int index)
    {
        for (int i = 0; i < LevesGame.Count; i++)
        {
            if (i == index)
            {
                LevesGame[i].gameObject.SetActive(true);
            }
            else
            {
                LevesGame[i].gameObject.SetActive(false);
            }

        }
    }
    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Q))
        {
            start++;
            select(start);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            start--;
            select(start);
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
            if (level.gameObject.activeSelf)
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

    public void SetTypeSpeed(TypeSpeed type)
    {
        typeSpeed = type;
        SaveType(typeSpeed);

    }
    public void SaveType(TypeSpeed type)
    {
        switch (type)
        {
            case TypeSpeed.Slow:
                PlayerPrefs.SetInt(Key_Type_Speed, 0);
                PlayerPrefs.Save();
                break;
            case TypeSpeed.Normal:
                PlayerPrefs.SetInt(Key_Type_Speed, 1);
                PlayerPrefs.Save();
                break;
            case TypeSpeed.Fast:
                PlayerPrefs.SetInt(Key_Type_Speed, 2);
                PlayerPrefs.Save();
                break;
        }
    }
    public TypeSpeed GetTypeSpeed(int type)
    {
        switch(type)
        {
            case 0:
                return TypeSpeed.Slow;
                break;
            case 1:
                return TypeSpeed.Normal;
                break;
            case 2:
                return TypeSpeed.Fast;
                break;
        }
        return TypeSpeed.Slow;
    }
    public float GetSpeed()
    {
        int type = PlayerPrefs.GetInt(Key_Type_Speed);
        switch(type)
        {
            case 0:
                return 0.2f;
                break;
            case 1:
                return 0.4f;
                break;

            case 2:
                return 0.6f;
                break;
        }
        return 0;
    }

    public int GetTypeSpeedInt()
    {
        return PlayerPrefs.GetInt(Key_Type_Speed);
    }

    public int GetCoins()
    {
        return PlayerPrefs.GetInt(Key_Coin);
    }

    public List<PageLevels> GetStageLevels()
    {
        return JsonUtility.FromJson<List<PageLevels>>(PlayerPrefs.GetString(Key_Infor_Stage_Levels));
    }

    public void UnLockNewStage(int Stage)
    {
        List<PageLevels> Levels = new List<PageLevels>();
        for(int i = 0; i < LevesGame.Count / 9; i++)
        {
            PageLevels pages = new PageLevels();
            pages.level = i;
            if (i <= Stage)
            {

                pages.Unlock = true;
            }
            else
            {
                pages.Unlock = false;
            }
            Levels.Add(pages);
         
        }
        StageLevels Stages = new StageLevels();
        Stages.Stages = Levels;
        string json = JsonUtility.ToJson(Stages);
        PlayerPrefs.SetString(Key_Infor_Stage_Levels, json);
        PlayerPrefs.Save();
    }

    public bool isUnLockPage(int levels)
    {
        if(levels == 0)
        {
            return true;
        }
        else
        {
            var a = GetStageLevels();

            int Starts = a[levels - 1].Stars;

               if(Starts >=9)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    

  
}



[System.Serializable]
public class StageLevels
{
    public List<PageLevels> Stages = new List<PageLevels>();


}
[System.Serializable]
public class PageLevels
{
    public int Stars;
    public int level;
    public bool Unlock = false;
}


