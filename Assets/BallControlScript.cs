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

	

	
	
	
	public bool MoveToHool;
	public Vector3 HoolTarget;

	public event System.Action<float> OnActionDie;


	void Start () {
		body = GetComponent<Rigidbody>();
		speedOnIce = 1;

	}



	// Update is called once per frame

	

	void Update () {
		if (Input.GetKeyDown(KeyCode.L))
		{
			SceneManager.LoadScene("GamePlay");
		}



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
		
			 dirY = Input.GetAxis("Vertical")   * moveSpeedModifier;
			 dirX = Input.GetAxis("Horizontal") * moveSpeedModifier;


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



}
