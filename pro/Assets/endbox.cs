using UnityEngine;
using System.Collections;

public class endbox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D collision)
	{		
		if(collision.tag == "Player")
		{
			print ("ok2");
			Application.LoadLevel("clear");
		}
		
	}


}

