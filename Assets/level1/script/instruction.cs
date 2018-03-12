using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instruction : MonoBehaviour {
	public GameObject instruc;
	float timer = 0f;
	public bool skip;
	//public Resume_Paused re;
	public AccelerationControlScript grass;
	public BattryChange jumpDilog ;
	public TimeText time;
	public Resume_Paused resume;
	public GameObject ins ;
	public Exit home ;

	// Use this for initialization
	void Start () {
		//skip = true;

		//to no button press
			Time.timeScale = 1;
			instruc.SetActive (true);
			time.enabled = false;
			grass.enabled = false;
			jumpDilog.enabled= false;
		resume.enabled = true;
		home.enabled = true;
//		bool pause=re.GetPause();
//		if (pause) {
//			Time.timeScale = 0;
//		//	back.SetActive (true);


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

			}	}

//	public void Skip(){
//		skip = !skip;
//		//to resume the game
//		if (!skip) {
//			Time.timeScale = 1;
//			instruc.SetActive (false);
//				grass.enabled = true;
//			//
//			time.enabled = true;
//			ins.SetActive (false);
//
//			}
//		} 



}
