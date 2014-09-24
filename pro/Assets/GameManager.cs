using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public GameObject box_1;
	public GameObject box_2;
	public GameObject box_3;
	
	COLOR_STATE ColorState = COLOR_STATE.RED;
	
	public Animator animator_1;
	public Animator animator_2;	
	public Animator animator_3;
	public GameObject door;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		string Name_1 = box_1.gameObject.name;
		string Name_2 = box_2.gameObject.name;
		string Name_3 = box_3.gameObject.name;
		
		
		if(Name_1 == "rgb_0" && animator_1.GetBool("red") == true && animator_1.GetBool("green") == false && animator_1.GetBool("blue") == false)
		{			
			if(Name_2 == "rgb_1" && animator_2.GetBool("green") == true && animator_2.GetBool("red") == false && animator_2.GetBool("blue") == false)
			{				
				if(Name_3 == "rgb_2" && animator_3.GetBool("blue") == true && animator_3.GetBool("red") == false && animator_3.GetBool("green") == false)
				{
					door.SetActive(false);
				}		
			}
		}
		
		
	
	}
}
