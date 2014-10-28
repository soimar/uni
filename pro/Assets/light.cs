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
	public GameObject end_here;
	public GameObject door;
	public BoxLightType type = BoxLightType.Up;
	public Vector3 beamAngle = new Vector3(0,0,90);
	public Vector3 beamEmitterPos = new Vector3(0,0,0);
	public bool light_check = false;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if(light_check == true)
		{
			beam.transform.localScale += new Vector3(0,0.15f,0);
		}

	}

	void Beam()
	{
		beam = (GameObject)Instantiate(beamPrefab, transform.position, Quaternion.Euler(beamAngle));
		beam.name = "beam_" + name;
		beam.transform.position += beamEmitterPos;
		beam.SendMessage ("SetLightPtr", this);
		beam.SetActive(light_check);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{	
		if ((collision.gameObject.tag == "beam") &&
		    (beam.name != collision.gameObject.name))
		{
			ShootBeam();
		}
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		if ((collision.gameObject.tag == "beam") &&
		    (beam.name != collision.gameObject.name))
		{
//			ShootBeam();
		}

	}


	void OnTriggerExit2D(Collider2D collision)
	{	
		if ((collision.gameObject.tag == "beam") &&
		    (beam.name != collision.gameObject.name))
		{
			EndBeam();
		}
	}
	
	void ShootBeam()
	{	
		light_check = true;
		beam.SetActive(true);
		beam.transform.position = transform.position + beamEmitterPos;
	}
	
	void PlayerBeam()
	{
		beam.transform.localScale = new Vector3(2,0,2);
		light_check = true;
	}
	
	
	void StopBeam( GameObject collision )
	{
		light_check = false;		
//		Vector3 len = transform.position - collision.transform.position;	
	}

	void EndBeam()
	{
//		Destroy(beam.gameObject);
//		light_check = false;
		beam.transform.localScale = new Vector3(2,0,2);
		//beam.SetActive(false);
		light_check = false;
	}

	void EndHere()
	{
		end_here.SetActive(true);
	}

	void StartBeam()
	{
		beam = (GameObject)Instantiate(beamPrefab, transform.position,Quaternion.Euler(beamAngle));
		beam.transform.position += beamEmitterPos;
		light_check = true;
	}
	
	
}
