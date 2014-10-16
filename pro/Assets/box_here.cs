using UnityEngine;
using System.Collections;

public class box_here : MonoBehaviour {
public GameObject box;
public GameObject door;
public GameObject door2;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
	
	void OnTriggerEnter2D(Collider2D collision)
	{		
		string colliderName = collision.collider2D.name;
		
		if(colliderName == "box")
		{
			box.SetActive(false);
			door.SetActive(false);
			door2.SetActive(false);
			this.gameObject.SetActive(false);
		}
	}
}
