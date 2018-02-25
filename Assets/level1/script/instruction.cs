using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instruction : MonoBehaviour {
	public GameObject instruc;
	float timer = 0f;

	public AccelerationControlScript grass;
	public GameObject jumpDilog ;
	public TimeText time;
	//public GameObject resume;

	public GameObject ins ;
	//public GameObject home ;

	// Use this for initialization
	void Start () {

		instruc.SetActive (true);
		time.enabled= false;
		grass.enabled = false;
		jumpDilog.SetActive (false);
		//resume.SetActive (true);
		//home.SetActive (true);

	}
	
	// Update is called once per frame
	 void Update ()
	{				
		//this time passed
		timer += Time.deltaTime;    
		if (timer >= 4) {

			instruc.SetActive (false);
			grass.enabled = true;

			time.enabled = true;
			ins.SetActive (false);

		}	


	}

}
