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
		
		
		
		if(Input.GetKeyUp(KeyCode.UpArrow) ||
		   Input.GetKeyUp(KeyCode.DownArrow) ||
		   Input.GetKeyUp(KeyCode.RightArrow) ||
		   Input.GetKeyUp(KeyCode.LeftArrow))
		{
			ani.SetTrigger("normal");
			playerState = PLAYER_STATE.NORMAL;
		}
		
		
	}
	
	
	
}
