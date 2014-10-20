using UnityEngine;
using System.Collections;

public class colli : MonoBehaviour {
	GameObject light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SetLight( GameObject li)
	{
		light = li;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{	
		light.SendMessage("m_light");
	}

}
