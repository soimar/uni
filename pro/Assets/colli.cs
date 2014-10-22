using UnityEngine;
using System.Collections;

public class colli : MonoBehaviour {
	public light lightBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetLightPtr( light li)
	{
		lightBox = li;
	}
	
	

//	void OnCollisionEnter2D(Collision2D collision)
	void OnTriggerEnter2D(Collider2D collision)
	{	
		if(collision.gameObject.tag == "Player")
		{
			print ("player");
			lightBox.SendMessage("PlayerBeam");
		}
		else if (collision.gameObject.tag == "wall")
		{
			lightBox.SendMessage("StopBeam", collision.gameObject);
		}
		else if (collision.gameObject.tag == "light_box")
		{
			lightBox.SendMessage("StopBeam", collision.gameObject);
			collision.gameObject.SendMessage("ShootBeam");
		}
		
		
	}
	
	void OnTriggerExit2D(Collider2D collision)
	{	
		if (collision.gameObject.tag == "light_box")
		{
			lightBox.SendMessage("EndBeam", collision.gameObject);
		}
		
	}
	


}