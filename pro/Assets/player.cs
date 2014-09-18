using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	public Animator ani;
	public enum PLAYER_STATE {
		NORMAL,
		WALK,
		JUMP,
		SHOOT,
		PUSH
	};
		
	PLAYER_STATE playerState = PLAYER_STATE.NORMAL;		
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//캐릭터 이동
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			if (playerState != PLAYER_STATE.WALK)
			{
				ani.SetTrigger("walk");
				playerState = PLAYER_STATE.WALK;
			}
			
			transform.rotation = Quaternion.Euler( new Vector3(0,0,90));
			transform.Translate(Vector3.up * 15 * Time.deltaTime);
			
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			if (playerState != PLAYER_STATE.WALK)
			{
				ani.SetTrigger("walk");
				playerState = PLAYER_STATE.WALK;
			}

			transform.rotation = Quaternion.Euler( new Vector3(0,0,270));
			transform.Translate(Vector3.up * 15 * Time.deltaTime);
		}
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			if (playerState != PLAYER_STATE.WALK)
			{
				ani.SetTrigger("walk");
				playerState = PLAYER_STATE.WALK;
			}

			transform.rotation = Quaternion.Euler( new Vector3(0,0,360));
			transform.Translate(Vector3.up * 15 * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			if (playerState != PLAYER_STATE.WALK)
			{
				ani.SetTrigger("walk");
				playerState = PLAYER_STATE.WALK;
			}

			transform.rotation = Quaternion.Euler( new Vector3(0,0,180));
			transform.Translate(Vector3.down * -15 * Time.deltaTime);
		}
		
		if(Input.GetKey(KeyCode.Z))
		{
			if (playerState != PLAYER_STATE.PUSH)
			{
				ani.SetTrigger("push");
				playerState = PLAYER_STATE.PUSH;
			}

			//transform.rotation = Quaternion.Euler( new Vector3(0,0,180));
		}
		

		
		if(Input.GetKeyUp(KeyCode.UpArrow) ||
		   Input.GetKeyUp(KeyCode.DownArrow) ||
		   Input.GetKeyUp(KeyCode.RightArrow) ||
		   Input.GetKeyUp(KeyCode.LeftArrow))
		{
			if(!Input.GetKey(KeyCode.UpArrow) &&
			   !Input.GetKey(KeyCode.DownArrow) &&
			   !Input.GetKey(KeyCode.RightArrow) &&
			   !Input.GetKey(KeyCode.LeftArrow))
			{
				if (playerState == PLAYER_STATE.WALK)
				{
					ani.SetTrigger("normal");
					playerState = PLAYER_STATE.NORMAL;
				}
			}
				
		}
		
		if (Input.GetKeyUp(KeyCode.Z))
		{
			print ("Z key up1");
			if(playerState == PLAYER_STATE.PUSH)
			{
				print ("Z key up2");
				
				ani.SetTrigger("normal");
				playerState = PLAYER_STATE.NORMAL;
				
				DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
				joint.enabled = false;
				if (joint.connectedBody)
				{
					joint.connectedBody.rigidbody2D.mass = 2000;
				}
			}
			/*
			else if(playerState == PLAYER_STATE.PUSH)
			{
				ani.SetTrigger("normal");
				playerState = PLAYER_STATE.NORMAL;
				

			}
/**/			
			
		}
				
						
	}
	
	
	
	
	
	void OnCollisionStay2D(Collision2D collision)
	{		
			if(playerState == PLAYER_STATE.PUSH)
			{
				if(collision.gameObject.tag == "box")
				{
					DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
					joint.enabled = true;
				
					collision.gameObject.rigidbody2D.mass = 1;
				
					joint.connectedBody = collision.rigidbody;
				
				}
			}
		
			/*else
			{
				collision.gameObject.rigidbody2D.mass = 2000;
				DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
				joint.enabled = false;
				
			}
			*/
	
	}
	
	
	
	
}
