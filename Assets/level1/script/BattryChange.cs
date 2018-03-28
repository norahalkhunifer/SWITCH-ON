using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattryChange : MonoBehaviour {


	// Use this for initialization
	public BattryChange BatrryHide;
	public GameObject battry_r;
	public GameObject battry_g;
	public GameObject battry_y;
	public GameObject ShowBattry;
	public AccelerationControlScript grass;
	public GameObject jump ;
	float timer = 0f;
public ThenderDisable thender;
	public GameObject charecter;
	public AudioSource dec;




	// Use this for initialization
	void Start () {
		//first start the game all battry is disactive with dailoge of jumping
		battry_g.SetActive (true);
		battry_y.SetActive (false);
		battry_r.SetActive (false);
		jump.SetActive (false);
		charecter.SetActive (false);


	}


	// Update is called once per frame
	void Update ()
	{		//this time passed

		timer += Time.deltaTime;    
		//after 5 sec make battry green disactive and yallow active
		if (timer >= 6) {

			battry_g.SetActive (false);
			battry_y.SetActive (true);
			dec.Play ();
		}
		//after 10 sec make battry yallow disactive and red active and jumping dailoge active

		if (timer >= 12) {
			battry_y.SetActive (false);
			battry_r.SetActive (true);
			jump.SetActive (true);
			charecter.SetActive (true);
			dec.Play ();

			//here make time passed is 0
			timer = 0;


			//make disenable this three script for grass remove and battry timer and thender

			thender.enabled=false;
			grass.enabled= false;
			BatrryHide.enabled = false;
			ShowBattry.SetActive (true);

			//make script of jumping to charging the battry active

		}


	}

}
