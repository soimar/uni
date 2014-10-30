using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	
	public rgb box_1;
	public rgb box_2;
	public rgb box_3;
	public light beam_start;
	public player hero;
	
	public GameObject UI;

	public GameObject item_stone;
	
	public GameObject door;
	public bool beamStart = false;
	
	// Use this for initialization
	void Start () {
		
		box_1.ColorState = COLOR_STATE.RED;
		box_2.ColorState = COLOR_STATE.RED;
		box_3.ColorState = COLOR_STATE.RED;
	}


	// Update is called once per frame
	void Update () {
				

				transform.position = new Vector3 (hero.transform.position.x, hero.transform.position.y,
		                                   transform.position.z);

		UI.transform.position = hero.transform.position - new Vector3 (0, 16, 0);


				if (box_1.ColorState == COLOR_STATE.RED) {
						if (box_2.ColorState == COLOR_STATE.GREEN) {				
								if (box_3.ColorState == COLOR_STATE.BLUE) {

										door.SetActive (false);

										if (!beamStart) {
												beam_start.SendMessage ("Beam");
												beamStart = true;
										}

								}		
						}
				}
		}


}
