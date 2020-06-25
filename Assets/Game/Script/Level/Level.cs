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
    private void Start()
    {

     
    }
    public void SetUp()
    {
        Items =  transform.GetComponentsInChildren<Item>();
        Ball = transform.GetComponentInChildren<BallControlScript>();
        PosInit = Ball.transform.position;
        var traps = transform.GetComponentsInChildren<FallHool>();
        foreach (var hool in traps)
        {
            hool.SetTarget();
        }

     
    }

    public virtual void ResetLevel()
    {
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
        Ball.transform.position = PosContinue;
        GameManager.Ins.isGameOver = false;
    }

    public void CloseLevel()
    {
        gameObject.SetActive(false);
    }
  

    

}
