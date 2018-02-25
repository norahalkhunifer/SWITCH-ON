using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Paused : MonoBehaviour {
	public bool pause;
	public GameObject resume;
	public GameObject back;
	// Use this for initialization
	void Start () {
		pause = false;
		resume.SetActive (false);
		back.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void onPause(){
		pause = !pause;
		//to resume the game
		if (!pause) {
			Time.timeScale = 1;
			resume.SetActive (false);
			back.SetActive (false);

			//to pause the level
		} else if (pause) {
			Time.timeScale = 0;
			resume.SetActive (true);
			back.SetActive (true);

		}
		
	}

}
