using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public rgb box_1;
	public rgb box_2;
	public rgb box_3;
	public light beam_start;

	
	public GameObject item_stone;
	
	public GameObject door;
	
	// Use this for initialization
	void Start () {
		
		box_1.ColorState = COLOR_STATE.RED;
		box_2.ColorState = COLOR_STATE.RED;
		box_3.ColorState = COLOR_STATE.RED;
		
	}


	
	// Update is called once per frame
	void Update () {
				
		if(box_1.ColorState == COLOR_STATE.RED)
		{
			if(box_2.ColorState == COLOR_STATE.GREEN)
			{				
				if(box_3.ColorState == COLOR_STATE.BLUE)
				{
					door.SetActive(false);
					beam_start.SendMessage("Beam");
				}		
			}
		}
	}


	void OnTriggerEnter2D(Collider2D collision)
	{		
		string colliderName = collision.collider2D.name;
		
		if(colliderName == "Player")
		{
			Application.LoadLevel("end");
		}
	}
	

}
