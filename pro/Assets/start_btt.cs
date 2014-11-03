using UnityEngine;
using System.Collections;

public class start_btt : MonoBehaviour {
	public GUITexture btt_UP;
	public GameObject btt_UP_obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		GUI_Check ();
	
	}


	void GUI_Check()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			if(btt_UP.HitTest(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)))
			{
				Application.LoadLevel ("play");
			}
		}
	}
}
