using UnityEngine;
using System.Collections;

public class light : MonoBehaviour {
	public GameObject beam;
	public bool light_check = true;
	GameObject clone_beam;
	
	// Use this for initialization
	void Start () {
		
		clone_beam = (GameObject)Instantiate(beam, transform.position ,Quaternion.Euler(0,0,90));
		clone_beam.SendMessage ("SetLight", this);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(light_check == true)
		{
			clone_beam.transform.localScale += new Vector3(0,0.2f,0);
		}
		
	}
	
		void m_light()
	{	
		light_check = false;
	}

}
