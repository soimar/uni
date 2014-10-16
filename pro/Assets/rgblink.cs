using UnityEngine;
using System.Collections;

public class rgblink : MonoBehaviour {
	
	public rgb box_1;

	public rgb box_key_1;

	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
		void OnCollisionEnter2D(Collision2D collision)
	{		
		if(collision.gameObject.tag == "item_stone")
		{
			if(box_key_1.ColorState == COLOR_STATE.RED)
			{			
				box_1.ani.SetBool("green",true);
				box_1.ani.SetBool("blue",false);
				box_1.ani.SetBool("red",false);
				
				box_key_1.ani.SetBool("green",true);
				box_key_1.ani.SetBool("blue",false);
				box_key_1.ani.SetBool("red",false);
			
				box_1.ColorState = COLOR_STATE.GREEN;
				box_key_1.ColorState = COLOR_STATE.GREEN;
			}
			else if(box_key_1.ColorState == COLOR_STATE.GREEN)
			{
				box_1.ani.SetBool("green",false);
				box_1.ani.SetBool("blue",true);
				box_1.ani.SetBool("red",false);
				
				box_key_1.ani.SetBool("green",false);
				box_key_1.ani.SetBool("blue",true);
				box_key_1.ani.SetBool("red",false);
			
				box_1.ColorState = COLOR_STATE.BLUE;
				box_key_1.ColorState = COLOR_STATE.BLUE;
			}
			else if(box_key_1.ColorState == COLOR_STATE.BLUE)
			{				
				box_1.ani.SetBool("green",false);
				box_1.ani.SetBool("blue",false);
				box_1.ani.SetBool("red",true);
				
				box_key_1.ani.SetBool("green",false);
				box_key_1.ani.SetBool("blue",false);
				box_key_1.ani.SetBool("red",true);
			
				box_1.ColorState = COLOR_STATE.RED;
				box_key_1.ColorState = COLOR_STATE.RED;
			}
		}

	}
	
	
	
}
