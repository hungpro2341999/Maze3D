using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControlScript : MonoBehaviour {

    
	[Header("InforBall")]
	[Range(0, 2f)]
	public float moveSpeedModifier = 0.5f;
	float dirX, dirY;
	public Rigidbody body;
	public float speedOnIce;
	public Animator AnimFallHoll;
	public float[] ArrAngle;
	public LayerMask Mask;
	
	public bool MoveToHool;
	public Vector3 HoolTarget;
	
	public event System.Action<float> OnActionDie;


	void Start () {
		
		body = GetComponent<Rigidbody>();
		speedOnIce = 1;
		AnimFallHoll = GetComponent<Animator>();
		Application.targetFrameRate = 60;
	}



	// Update is called once per frame

	

	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
		{

		
			//Debug.Log("End ::: ");
			//SetPosRespawn(new Vector3(1.823f, transform.position.y, 2.152f),new Vector3(2.299f, 0, 2.1f));
		}


		if (Input.GetKeyDown(KeyCode.L))
		{
			SceneManager.LoadScene("GamePlay");
		}

		if (GameManager.Ins.isGameOver || GameManager.Ins.isGamePause)

			return;

		if (OnActionDie!=null)
		{
			//body.velocity = Vector3.zero;
			//body.isKinematic = true;
			//transform.position = Vector3.MoveTowards(transform.position, HoolTarget, Time.deltaTime);
			//if(transform.position == HoolTarget)
			//{
				
			//	MoveToHool = false;
			//}
			//dirX = 0;
			//dirY = 0;

			OnActionDie(Time.deltaTime);
		}
		else
		{
		
			 //dirY = Input.GetAxis ("Vertical")   * moveSpeedModifier;
			 //dirX = Input.GetAxis("Horizontal") * moveSpeedModifier;
			dirY = Input.acceleration.y * moveSpeedModifier;
			dirX = Input.acceleration.x * moveSpeedModifier;

		}

	}

	void FixedUpdate()
	{
	
		if (!MoveToHool)
		body.velocity = new Vector3 ((body.velocity.x  + dirX), 0,(body.velocity.z) + dirY);
	}

	
	public void FallHool()
	{
	    
	}




	public void Move_To_Hool(Vector3 position)
	{
		HoolTarget = position;
		MoveToHool = true;

	}

	public void AddOnActionDie(System.Action<BallControlScript> TriggerTrap, System.Action<BallControlScript> ActionActive,System.Action EndAction,float timeEnd)
	{

		 StartAcionWithTime(TriggerTrap, ActionActive, EndAction, timeEnd);

	}
	//public Vector3 SetPosFollowDirect(Vector3 direct,float dis, Vector3 target)
	//{
	//	dis  += 0.05f;
	//	Vector3 pos = target + direct * dis;
	//	while (true)
	//	{
	//		RaycastHit hit;
	//		if (Physics.SphereCast(new Vector3(pos.x, -10.2f, pos.y), 0.2f, transform.up, out hit, 0.2f, Mask))
	//		{
	//			pos = target + direct * dis;
	//			dis += 0.05f;
	//			continue;
	//		}
	//		else
	//		{
	//			break;
	//		}
	//	}
	//}
    public Vector3 SetPosRespawn(Vector3 FallHoll,Vector3 target,Vector3 Axit)
    {


		Debug.Log("Axit : " + Axit);
		int layer = gameObject.layer;
		gameObject.layer = 2;


		Debug.Log("Target : " + target + " Fall Holl " + FallHoll);
		Vector2 direct = (new Vector2(FallHoll.x,FallHoll.z) - new Vector2(target.x,target.z)).normalized;
		float radius = 0.4f;
		int i = 0;
		int loop = 0;
		while (true)
		{
			loop++;
			if (loop >= 1000)
			{
				Debug.Log("Can't not find Pos");
				break;
			}
			i++;
			
			if (i >= ArrAngle.Length)
			{
				i=0;
				radius += 0.02f;
			}
			
		    
			//Debug.Log("Target : "+target +" Fall Holl "+ FallHoll);



			//	Vector2 posRandom = List_direct[UnityEngine.Random.Range(0, List_direct.Count)].normalized;

			Vector2 posRandom;
			//if (Vector3.Angle(new Vector3(direct.x, 0, direct.y), Axit) > 90)
			//{
			//	continue;
			//}
			var vForce = Quaternion.AngleAxis(ArrAngle[i], Vector3.up) * Axit;
			Debug.Log("Angle : " + vForce +" "+i);
			if (Vector3.Angle(new Vector3(direct.x, 0, direct.y), vForce) >= 100)
			{
				continue;
			}

			posRandom = vForce.normalized;
			Vector2 axit = posRandom;
			if (Vector3.Angle(vForce, new Vector3(direct.x, 0, direct.y)) > 90)
			{
				continue;
			}


			Vector2 pos = new Vector2(target.x,target.z) + posRandom * radius;

			Debug.Log("PosDirect : " + pos);

			//if (Physics.Raycast(new Ray(new Vector3(target.x, transform.position.y, target.z), new Vector3(posRandom.x, 0, posRandom.y).normalized),
			//	Vector2.Distance(new Vector2(pos.x, pos.y), new Vector2(target.x, target.z))))
			//{
			//	Debug.Log("Block");
			//	continue;
			//}

			Debug.Log(target + "  " + posRandom + "  " + radius + " Result :  " + pos);

			RaycastHit hit;

			if(Physics.SphereCast(new Vector3(pos.x, -10.2f, pos.y), 0.2f, transform.up, out hit,0.2f, Mask))
			{

			  
				Debug.Log(target + "  " + posRandom + "  " + radius + " Result :  " + pos + "Coll_With :"+ hit.collider.gameObject.name);
				continue;
			}
			else
			{


				Debug.Log(axit + "  " + direct + " = " + Vector2.Angle(direct, axit));
				Debug.Log("Pos APPCET : " + pos + " ||  LOOP : " + loop);
			
				//transform.position = new Vector3(pos.x, transform.position.y, pos.y);
				return new Vector3(pos.x, transform.position.y, pos.y);

			}
			
			
		}
		return Vector3.zero;
	}

    public void ResetBall()
	{
		
		OnActionDie = null;
		body.isKinematic = false;
		AnimFallHoll.SetBool("Die", false);
	}

	public void Done()
	{
		Debug.Log("Comple Method");
	}


	public void StartAcionWithTime(System.Action<BallControlScript> ActionTrigger, System.Action<BallControlScript> ActionUpdate, System.Action ActionRemove, float time)
	{
		if (ActionTrigger != null)
		{
			ActionTrigger(this);
		}

		System.Action expireAction = () =>
		{
			if (ActionRemove != null)
			{
				ActionRemove();
			}

		};

		System.Action<float> UpdateAction = (t) =>
		{
			ActionUpdate(this);

		};


		SetupTimer(time, UpdateAction, expireAction);



	}


	System.Action SetupTimer(float seconds, System.Action<float> updateAction, System.Action expireAction)
	{

		float timer = 0;

		System.Action expireWrapper = null;

		System.Action<float> updateWrapper = null;
		updateWrapper = (dt) =>
		{
			timer += dt;

			if (updateAction != null)
			{
				updateAction(dt);
			}

			if (timer >= seconds)
			{
				expireWrapper();
			}
		};

		OnActionDie += updateWrapper;



		expireWrapper = () =>
		{
			OnActionDie -= updateWrapper;



			if (expireAction != null)
			{
				expireAction();
			}
		};

		return expireWrapper;
	}
	private void OnDrawGizmos()
	{
		RaycastHit hit;
		//Debug.Log(new Vector3(transform.position.x, transform.position.y, transform.position.z));
		//if (Physics.SphereCast(new Vector3(transform.position.x, -10.1f, transform.position.z), 0.3f, transform.up, out hit, 0.3f, Mask))
		//{
		//	Debug.Log("Hit : " + hit.collider.gameObject.name);
		//}
		//else
		//{
		//	Debug.Log("Not Coll");
		//}
	}



}
