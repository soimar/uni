using UnityEngine;
using System.Collections;

public class rgb : MonoBehaviour {
public GameObject char_0;	
public Animator ani;
public enum COLOR_STATE {
		RED,
		GREEN,
		BLUE,
		
	};
		
	COLOR_STATE ColorState = COLOR_STATE.RED;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	
	
	void OnTriggerEnter2D(Collider2D collision)
	{		
		string colliderName = collision.collider2D.name;
		
		if(colliderName == "char_0")
		{
			if(ColorState == COLOR_STATE.RED)
			{
				ani.SetBool("green",true);
				ani.SetBool("blue",false);
				ani.SetBool("red",false);
								
				ColorState = COLOR_STATE.GREEN;
			}
			
			else if(ColorState == COLOR_STATE.GREEN)
			{
				ani.SetBool("blue",true);
				ani.SetBool("green",false);
				ani.SetBool("red",false);
				ColorState = COLOR_STATE.BLUE;
			}
			else if(ColorState == COLOR_STATE.BLUE)
			{
				ani.SetBool("red",true);
				ani.SetBool("green",false);
				ani.SetBool("blue",false);
				
				ColorState = COLOR_STATE.RED;
			}
		}
	}
	
	
	
	
	
	
	
}
