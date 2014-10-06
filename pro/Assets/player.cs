using UnityEngine;
using System.Collections;



public class player : MonoBehaviour {
	public Animator ani;
	public enum PLAYER_STATE {
		NORMAL,
		WALK,
		JUMP,
		PUSH
	};
	
public GUITexture GUI_stone;
public stone item_stone;

public GameObject stone_prefab;
	
	bool item = false;
	bool coll_stone = false;
	
	
		
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
				ani.SetBool("walk",true);
				playerState = PLAYER_STATE.WALK;
			}
			
			DistanceJoint2D joint = GetComponent<DistanceJoint2D>();			
			if (!joint.enabled)
			{
				transform.rotation = Quaternion.Euler( new Vector3(0,0,90));
				transform.Translate(Vector3.up * 15 * Time.deltaTime);
				//rigidbody2D.AddForce( new Vector3(1,0,0) * -150 * Time.deltaTime );
			}
			else
			{
				transform.position += new Vector3(1,0,0) * -15 * Time.deltaTime;

				Vector2 dir = joint.connectedBody.position - new Vector2(transform.position.x,
					transform.position.y);
				dir.Normalize();
				transform.rotation = Quaternion.FromToRotation(new Vector3(0,1,0), 
					new Vector3(dir.x, dir.y, 0));				
			}
			
		}
		if(Input.GetKey(KeyCode.RightArrow))
		{
			if (playerState != PLAYER_STATE.WALK)
			{
				
				ani.SetBool("walk",true);
				playerState = PLAYER_STATE.WALK;
			}
			
			DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
			if (!joint.enabled)
			{
				transform.rotation = Quaternion.Euler( new Vector3(0,0,270));
				transform.Translate(Vector3.up * 15 * Time.deltaTime);
				//rigidbody2D.AddForce( new Vector3(1,0,0) * 150 * Time.deltaTime );
			}
			else
			{
				//transform.Translate(new Vector3(1,0,0) * 15 * Time.deltaTime);
				//rigidbody2D.AddForce( new Vector3(1,0,0) * 150 * Time.deltaTime );
				
				transform.position += new Vector3(1,0,0) * 15 * Time.deltaTime;

				Vector2 dir = joint.connectedBody.position - new Vector2(transform.position.x,
					transform.position.y);
				dir.Normalize();
				transform.rotation = Quaternion.FromToRotation(new Vector3(0,1,0), 
					new Vector3(dir.x, dir.y, 0));				
				

			}
		}
		
		if(Input.GetKey(KeyCode.UpArrow))
		{
			if (playerState != PLAYER_STATE.WALK)
			{
				
				ani.SetBool("walk",true);
				playerState = PLAYER_STATE.WALK;
			}
			
			DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
			if (!joint.enabled)
			{
				transform.rotation = Quaternion.Euler( new Vector3(0,0,360));
				transform.Translate(Vector3.up * 15 * Time.deltaTime);
			}
			else
			{
				transform.position += new Vector3(0,1,0) * 15 * Time.deltaTime;

				Vector2 dir = joint.connectedBody.position - new Vector2(transform.position.x,
					transform.position.y);
				dir.Normalize();
				transform.rotation = Quaternion.FromToRotation(new Vector3(0,1,0), 
					new Vector3(dir.x, dir.y, 0));				
		

			}
			
			
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			if (playerState != PLAYER_STATE.WALK)
			{
				ani.SetBool("walk",true);
				playerState = PLAYER_STATE.WALK;
			}
			
			DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
			if (!joint.enabled)
			{
				transform.rotation = Quaternion.Euler( new Vector3(0,0,180));
				transform.Translate(Vector3.down * -15 * Time.deltaTime);
			}
			else
			{
				//transform.Translate(Vector3.down * 15 * Time.deltaTime);
				transform.position += new Vector3(0,1,0) * -15 * Time.deltaTime;

				Vector2 dir = joint.connectedBody.position - new Vector2(transform.position.x,
					transform.position.y);
				dir.Normalize();
				transform.rotation = Quaternion.FromToRotation(new Vector3(0,1,0), 
					new Vector3(dir.x, dir.y, 0));				
		

			}
		}
		
		
		// push
		
		if(Input.GetKey(KeyCode.Z))
		{
			ani.SetBool("push",true);
			
			if (playerState != PLAYER_STATE.PUSH)
			{
				playerState = PLAYER_STATE.PUSH;
			}
			
			DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
			if (joint.enabled)
			{
				Vector2 length = joint.connectedBody.position - new Vector2(transform.position.x, transform.position.y);
				if (5 < length.magnitude)
					joint.enabled = false;				
			}

			//transform.rotation = Quaternion.Euler( new Vector3(0,0,180));
		}
		
		
		//shoot
		
		if(Input.GetKeyDown(KeyCode.X))
		{
			ani.SetTrigger("shoot");
			item = false;
			coll_stone = false;
			item_stone.transform.position = transform.position;
			item_stone.gameObject.SetActive(true);
			
			
			stone stoneNew = (stone)Instantiate(stone_prefab);
			
			Vector3 dir = Quaternion.Euler(transform.rotation.eulerAngles) * new Vector3(0,1,0);
			dir.Normalize();
			
			stoneNew.Shoot(dir);
			StartCoroutine("Wait2", 3);
		}
		
		if(Input.GetKeyUp(KeyCode.X))
		{
			playerState = PLAYER_STATE.NORMAL;
		}
		
		
		//jump
		
		if(Input.GetKeyDown(KeyCode.C))
		{
			if(playerState == PLAYER_STATE.NORMAL)
			{
				ani.SetBool("jump",true);
				//ani.SetBool("normal",false);
				playerState = PLAYER_STATE.JUMP;
			}
		}
		
		if(Input.GetKeyUp(KeyCode.C))
		{
			if(playerState == PLAYER_STATE.JUMP)
			{
				//ani.SetBool("normal",true);
				ani.SetBool("jump",false);
				playerState = PLAYER_STATE.NORMAL;
			}
		}
		
		if(Input.GetKeyDown(KeyCode.Space))
		{	
			if(item == false && coll_stone == true)
			{
				ani.SetBool("item", true);
				ani.SetBool("normal",false);
					
				StartCoroutine("Wait2", 1);
					
				item = true;
				GUI_stone.gameObject.SetActive(true);
				item_stone.gameObject.SetActive(false);
				
			}
			else if(item == true)
			{
				ani.SetBool("item",false);
				ani.SetBool("normal",true);
				
				item = false;
				GUI_stone.gameObject.SetActive(false);
				item_stone.gameObject.SetActive(true);
				
				item_stone.transform.position = transform.position;
				
				coll_stone = false;
				
				
			}			
		}
		
		
		
		//move KeyUp
		
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
				ani.SetBool("walk",false);
				
				if (playerState == PLAYER_STATE.WALK)
				{
					//walk = false;
					playerState = PLAYER_STATE.NORMAL;
				}
			}
				
		}
		
		if (Input.GetKeyUp(KeyCode.Z))
		{
			ani.SetBool("push",false);
			
			if(playerState != PLAYER_STATE.NORMAL)
			{
				DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
				joint.enabled = false;
				
				if (joint.connectedBody)
				{
					joint.connectedBody.rigidbody2D.mass = 2000;
				}
			
				playerState = PLAYER_STATE.NORMAL;
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
	
	
	
	public IEnumerator Wait2(float delayTime)
	{
		yield return new WaitForSeconds(delayTime);
	}
	
	
	
	void OnCollisionStay2D(Collision2D collision)
	{		
			if(playerState == PLAYER_STATE.PUSH)
			{
				if(collision.gameObject.tag == "box")
				{
					DistanceJoint2D joint = GetComponent<DistanceJoint2D>();
					joint.enabled = true;
				
					collision.gameObject.rigidbody2D.mass = 0;
				
					joint.connectedBody = collision.rigidbody;
				
				}
			}
			
			if(Input.GetKeyDown(KeyCode.Space))
			{	
				if(collision.gameObject.tag == "item_stone")
				{	
					coll_stone = true;
				}
				else
				{
					coll_stone = false;
				}
				
			}
		
			
	
	}
	
	
	

	
}
