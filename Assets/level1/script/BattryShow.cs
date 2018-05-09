using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattryShow : MonoBehaviour {

	public float keyDelay = 1f;
	private float timePassed = 0;
	int count = 0;
	public GameObject battry0;
	public GameObject battry1;
	public GameObject battry2;
	string temp;
	string temp2;
	int num; 
	public BattryChange BatrryHide;	
	public AccelerationControlScript grass;
	Vector3 accelerationDir;
	public GameObject jump ;
	public GameObject charecter;
	public ThenderDisable thender;
//	public GameObject back;

	public GameObject ShowBattry;
	public AudioSource increse;


	// Update is called once per frame
	void Update () {
		//read the jumping of phone

		accelerationDir = new Vector3(0,Input.acceleration.y,0);
		//this time betwwen two battry and jumping

		timePassed += Time.deltaTime; 
		//to make sure the jumping is happend
		if (accelerationDir.sqrMagnitude >= 3f && timePassed >= keyDelay && count < 3) {
			//to make sure the count in battry red
			if (count == 0) {
				//active of battry red and disactive jumping dailoge

				battry0.SetActive (true);
				charecter.SetActive (true);
				jump.SetActive (false);		//here jump sound


			}
			if (count == 1) {
				//disactive of battry red and active battry yallow
				increse.Play();
				battry0.SetActive (false);
				battry1.SetActive (true);		//here jump sound

			}
			if (count == 2) {
				//disactive of battry yallow and active battry green

				increse.Play();
				battry1.SetActive (false);

				battry2.SetActive (true);
				charecter.SetActive (false);

			}

			//reset the time passed to restart to another object 
			timePassed = 0;
			//here increes the counter to another object
			count++;
			//to make sure the charging the battry end
		}
		else if (count == 3) {
			//make enable this two script for grass remove and battry timer
			count = 0;
			thender.enabled =true;
			BatrryHide.enabled= true;
			grass.enabled=true;  
			//back.SetActive (false);
		ShowBattry.SetActive (false);

					}
	}
}
