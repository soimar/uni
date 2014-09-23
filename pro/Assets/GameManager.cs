using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject box_1;
	public GameObject box_2;
	public GameObject box_3;
	
	COLOR_STATE ColorState = COLOR_STATE.RED;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(colliderName == "box_1")
		{
			if(ColorState == COLOR_STATE.RED)
			{
				print ("ok1");
			}
			
			if(colliderName == "box_2")
			{
				if(ColorState == COLOR_STATE.GREEN)
				{
					print ("ok2");
				}
				
				if(colliderName == "box_3")
				{
					if(ColorState == COLOR_STATE.BLUE)
					{
						print ("ok3");
					}
				}
					
			}
			
			
		}
		
		
	
	}
}
