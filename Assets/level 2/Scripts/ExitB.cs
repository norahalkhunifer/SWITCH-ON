using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitB : MonoBehaviour {

	public bool exitButton;
	public GameObject exitDilog;
	//public GameObject back;
	private LevelManger level;
	public Resumepaused re;
	// Use this for initialization
	void Start () {
		exitButton = false;
		exitDilog.SetActive (false);
		//back.SetActive (false);

	}


	public void onNo(){
		exitButton = !exitButton;

		//to no button press
		if (!exitButton) {
			Time.timeScale = 1;
			exitDilog.SetActive (false);
			//back.SetActive (false);
			bool pause=re.GetPause();
			if (pause) {
				Time.timeScale = 0;
				//back.SetActive (true);

			}
		} 


	}
	public void onHome(){
		exitButton = !exitButton;
		if (exitButton) {
			Time.timeScale = 0;
			exitDilog.SetActive (true);
			//back.SetActive (true);
		}
	}


	public void onYes(){
		exitButton = !exitButton;
		//to no button press
		if (!exitButton) {
			SceneManager.LoadScene ("world");
			Time.timeScale = 1;
			exitDilog.SetActive (false);
			//back.SetActive (false);
		}
	}
}
