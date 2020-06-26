using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHool : Trap
{
    [SerializeField]
    private const float speed = 1;
    [SerializeField]
    public Vector3 Target;
    private void Start()
    {
        timeEnd = 0.5f;
    }


    public override void TrapActive(BallControlScript ball)
    {
        
        Vector3 postion = ball.transform.position;

        ball.transform.position = Vector3.MoveTowards(new Vector3(ball.transform.position.x,ball.transform.position.y,ball.transform.position.z), 
                                                      new Vector3(Target.x, ball.transform.position.y, Target.z), Time.deltaTime);
         if(Vector3.Distance(ball.transform.position,new Vector3(Target.x, ball.transform.position.y, Target.z)) == 0)
        {
          
        }

        

    }

    public override void TriggerTrap(BallControlScript ball)
    {
        ball.body.isKinematic = true;
        ball.body.velocity = Vector3.zero;
        ball.AnimFallHoll.SetBool("Die", true);
        SetPosRespawn(ball);
    }




    public override void EndTrap()
    {
        Debug.Log("OverGame");
        GameManager.Ins.isGameOver = true;
        GameManager.Ins.OpenWindown(TypeWindown.OverGame);

    }

    public void SetTarget()
    {
        //if (GetComponent<Renderer>() != null)
        //{
        //    Target = GetComponent<Renderer>().bounds.center;
        //}
        //else
        //{
        //    Target = transform.position;
        //}
        //if (transform.GetComponentInChildren<Transform>())
        //{
        //    Target = GetComponent<Renderer>().bounds.center;
        //}
        //else
        //{
        //    Target = transform.position;
        //}
        Debug.Log(transform.GetChild(0).position);
        Target =  transform.GetChild(0).transform.position;
    }

    public void SetPosRespawn(BallControlScript ball)
    {
     

       // Vector3 posRespawn;
        Vector3 DirectRespawn = (ball.transform.position - new Vector3(Target.x, ball.transform.position.y, Target.z)).normalized;
        Vector3 posRespawn = ball.SetPosRespawn(ball.transform.position,Target);
        GamePlayCtrl.Ins.GetCurrLevel().PosContinue = posRespawn;
         
        

        
    }





}
