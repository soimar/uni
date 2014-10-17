using UnityEngine;
using System.Collections;

public class light : MonoBehaviour {
	public GameObject beam;
	public bool m_light = true;
	GameObject clone_beam;
	
	// Use this for initialization
	void Start () {
		
		clone_beam = (GameObject)Instantiate(beam, transform.position ,Quaternion.Euler(0,0,90));
	}
	
	// Update is called once per frame
	void Update () {
		
		if(m_light == true)
		{
			
			clone_beam.transform.localScale += new Vector3(0,0.2f,0);
		}
		
	}
	
		void OnCollisionEnter2D(Collision2D collision)
	{		
		print ("ok");
		m_light = false;

	}
}
