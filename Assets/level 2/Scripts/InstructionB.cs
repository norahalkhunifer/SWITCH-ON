using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionB : MonoBehaviour {

	public GameObject instruc;
	float timer = 0f;

	//public AccelerationControlScript grass;
	//public GameObject jumpDilog ;
	public GameObject b;
	public Level2Manager l2m;
	//public Resume_Paused resume;

	//public GameObject ins ;
	public ExitB home ;

	// Use this for initialization
	void Start () {

		instruc.SetActive (true);
		l2m.time.enabled= false;
		//grass.enabled = false;
		b.SetActive (false);
		//resume.enabled =true;
		home.enabled =true;
		l2m.activateGray (true);

	}

	// Update is called once per frame
	void Update ()
	{				
		//this time passed
		timer += Time.deltaTime; 

		if (timer >= 6) {

			instruc.SetActive (false);
			//b.enabled = true;

			l2m.time.enabled = true;
			l2m.activateGray (false);
			//ins.SetActive (false);

		}	


	}

}
