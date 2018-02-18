using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour {

	public bool exitButton;
	public GameObject exitDilog;
	public GameObject back;
	// Use this for initialization
	void Start () {
		exitButton = false;
		exitDilog.SetActive (false);
		back.SetActive (false);

	}

	// Update is called once per frame
	void Update () {

	}
	public void onPause(){
		exitButton = !exitButton;
		//to resume the game
		if (!exitButton) {
			Time.timeScale = 1;
			exitDilog.SetActive (false);
			back.SetActive (false);

			//to pause the level
		} else if (exitButton) {
			Time.timeScale = 0;
			exitDilog.SetActive (true);
			back.SetActive (true);
		}

	}
}
