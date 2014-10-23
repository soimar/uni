using UnityEngine;
using System.Collections;

public enum BoxLightType
{
	Up,
	Left,
	Down	
}

public class light : MonoBehaviour {
	public GameObject beamPrefab;
	public GameObject beam;
	public BoxLightType type = BoxLightType.Up;
	public Vector3 beamAngle = new Vector3(0,0,90);
	public Vector3 beamEmitterPos = new Vector3(0,0,0);
	public bool light_check = false;
	
	// Use this for initialization
	void Start () {
		
		beam = (GameObject)Instantiate(beamPrefab, transform.position,Quaternion.Euler(beamAngle));
		beam.transform.position += beamEmitterPos;
		beam.SendMessage ("SetLightPtr", this);
		beam.SetActive(light_check);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(light_check == true)
		{
			beam.transform.localScale += new Vector3(0,0.15f,0);
		}
		
	}
	
	void ShootBeam()
	{	
		light_check = true;
		beam.SetActive(true);
	}
	
	void PlayerBeam()
	{
		beam.transform.localScale = new Vector3(2,2,2);
		light_check = true;
	}
	
	
	void StopBeam( GameObject collision )
	{
		light_check = false;
		
		Vector3 len = transform.position - collision.transform.position;	
	}

	void EndBeam()
	{
		Destroy(beam.gameObject);
		light_check = false;
	}

	void StartBeam()
	{
		beam = (GameObject)Instantiate(beamPrefab, transform.position,Quaternion.Euler(beamAngle));
		beam.transform.position += beamEmitterPos;
		light_check = true;
	}
	
	
}
