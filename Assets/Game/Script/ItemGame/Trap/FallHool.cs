using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallHool : Trap
{
    public enum TypeRespawn { Default,Auto};
    [SerializeField]
    private const float speed = 1;
    [SerializeField]
    public Vector3 Target;
    public Vector3 Axit;
    public Vector3 PosRespawn;
    public TypeRespawn type;
    [SerializeField]
    public ArrayPointSpawn[] ArrayRespawn;
    
    private void Start()
    {
        GetComponent<SphereCollider>().radius = 0.09f;
        GetComponent<SphereCollider>().isTrigger = true;
        timeEnd = 0.35f;
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
        if (ball.isAutoRespawn)
        {
            Vector3 posRespawn = new Vector3(ball.posRespawn.x, ball.transform.position.y, ball.posRespawn.z);
            GamePlayCtrl.Ins.GetCurrLevel().PosContinue = posRespawn;
        }
        else
        {
            SetPosRespawn(ball);
        }
        ball.body.isKinematic = true;
        ball.body.velocity = Vector3.zero;
        ball.AnimFallHoll.SetBool("Die", true);
      
    }




    public override void EndTrap()
    {
        Debug.Log("OverGame");
        GameManager.Ins.isGameOver = true;
        GameManager.Ins.OpenSingleWindown(TypeWindown.OverGame);

    }

    public virtual void SetTarget()
    {
        if (GetComponent<Renderer>() != null)
        {
            Target = GetComponent<Renderer>().bounds.center;
        }
        else
        {
            Target = transform.position;
        }
        if (transform.GetComponentInChildren<Transform>())
        {
            Target = GetComponent<Renderer>().bounds.center;
        }
        else
        {
            Target = transform.position;
        }

        Debug.Log(gameObject.name);

        

        //if (type == TypeRespawn.Default)
        //{
        //    if (transform.GetChild(0) != null)
        //        PosRespawn = transform.GetChild(0).transform.position;
        //}
        //else if(type == TypeRespawn.Auto)
        //{
          
           
            
        //    for (int i= 0; i < 2; i++)
        //    {
        //        ArrayRespawn[i].posRespawn = transform.GetChild(i).transform.position;
        //    }
        //}


    }

    public void SetPosRespawn(BallControlScript ball)
    {
      
       if(type == TypeRespawn.Auto)
        {
            //Vector3 posRespawn;
            //Vector3 DirectRespawn = (ball.transform.position - new Vector3(Target.x, ball.transform.position.y, Target.z)).normalized;
            //posRespawn = ball.SetPosRespawn(ball.transform.position, Target ,Axit);
            //posRespawn = new Vector3(posRespawn.x, ball.transform.position.y, posRespawn.z);
            //GamePlayCtrl.Ins.GetCurrLevel().PosContinue = posRespawn;

            Vector3 direct = (ball.transform.position - Target).normalized;
            float angle = 1000;
            ArrayPointSpawn Arr = null;
            for(int i = 0; i < ArrayRespawn.Length; i++)
            {

                var a = Vector3.Angle(ArrayRespawn[i].Axit, direct);
                if (a < angle)
                {
                    angle = a;
                    Arr = ArrayRespawn[i];
                }
            }

            GamePlayCtrl.Ins.GetCurrLevel().PosContinue = new Vector3(Arr.posRespawn.x,ball.transform.position.y,Arr.posRespawn.z);





        }
        else
        {
            Vector3 posRespawn = new Vector3(PosRespawn.x, ball.transform.position.y, PosRespawn.z);
            GamePlayCtrl.Ins.GetCurrLevel().PosContinue = posRespawn;

        }





    }
   [System.Serializable]
    public class ArrayPointSpawn
    {
        public Vector3 Axit;
        public Vector3 posRespawn;

    }



}
