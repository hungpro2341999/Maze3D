using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int level;
    
    public Item[] Items;
    public BallControlScript Ball;
    public Vector3 PosInit;
    public Vector3 PosContinue;
    public bool levelComplete = false;
    public float FieldOfView;
    public float horizontalFOV = 32f;
    public bool Test = false;
    public System.Action ResetContinueGame;

    public LockGem GetLocKGemCurr()
    {
        foreach(var locks in Items)
        {
            if(locks is LockGem)
                {
                return (LockGem)locks;
                }
        }
        return null;
    }



    private void Start()
    {
        Test = true;
        float defaultResolotion = 720;

        float per = Screen.width / defaultResolotion;
        Debug.Log("WITH CURR : " + Screen.width);
        FieldOfView =  FieldOfView * per;
        ResetLevel();


      


        //somewhere in update if screen is resizable
        


    }
    private void OnEnable()
    {
        Camera.main.fieldOfView = calcVertivalFOV(horizontalFOV, Camera.main.aspect);
    }

    private void Update()
    {
        if (!Test)
            return;
        Camera.main.fieldOfView = calcVertivalFOV(horizontalFOV, Camera.main.aspect);
    }
    private float calcVertivalFOV(float hFOVInDeg, float aspectRatio)
    {
        float hFOVInRads = hFOVInDeg * Mathf.Deg2Rad;
        float vFOVInRads = 2 * Mathf.Atan(Mathf.Tan(hFOVInRads / 2) / aspectRatio);
        float vFOV = vFOVInRads * Mathf.Rad2Deg;
        return vFOV;
    }
    public void SetUp()
    {
        Items =  transform.GetComponentsInChildren<Item>();
        Ball = transform.GetComponentInChildren<BallControlScript>();
        Debug.Log(transform.name);
        PosInit = Ball.transform.position;
        var traps = transform.GetComponentsInChildren<FallHool>();
        foreach (var hool in traps)
        {
            hool.SetTarget();
        }
        var Ground = transform.GetComponentsInChildren<GroundHool>();
        foreach (var hool in Ground)
        {
            hool.SetTarget();
        }
        

    }
    private void OnDrawGizmos()
    {
        Camera.main.fieldOfView = calcVertivalFOV(horizontalFOV, Camera.main.aspect); 
    }
    public virtual void ResetLevel()
    {
        CtrlEvaluatePlayer.timeInSeconds = 0;
        Camera.main.fieldOfView = FieldOfView;
        GameManager.Ins.isGameOver = false;
        foreach(var item in Items)
        {
            item.ResetItem();
        }
        Ball.transform.position = new Vector3(PosInit.x, Ball.transform.position.y, PosInit.z);
      
        
        Ball.ResetBall();
    }

    public void StartLevel()
    {
        gameObject.SetActive(true);
        ResetLevel();


    }
    public void ContinueLevel()
    {
        Ball.transform.position = new Vector3(PosContinue.x,PosInit.y,PosContinue.z);
        GameManager.Ins.isGameOver = false;
        Ball.body.velocity = Vector3.zero;
        Ball.AnimFallHoll.SetBool("Die", false);
        Ball.body.isKinematic = false;
        Ball.Die = false;
        Ball.moveSpeedModifier = GamePlayCtrl.Ins.GetSpeed();
        if(ResetContinueGame!=null)
        {
            ResetContinueGame();
        }
    }

    public void CloseLevel()
    {
        gameObject.SetActive(false);
    }
  

    

}
