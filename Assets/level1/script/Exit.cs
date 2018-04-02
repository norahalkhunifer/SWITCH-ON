using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	
	public bool exitButton;
	public GameObject exitDilog;
	public GameObject back;
	private LevelManger level;
	public Resume_Paused re;
	public GameObject resumeDe;
	public Button resumeButton;
	public LevelManger levelmaneger;
	// Use this for initialization
	void Start () {
		exitButton = false;
		exitDilog.SetActive (false);
		back.SetActive (false);

	}


	public void onNo(){
		exitButton = !exitButton;

		//to no button press
		if (!exitButton) {
			Time.timeScale = 1;
			exitDilog.SetActive (false);
			back.SetActive (false);
			resumeDe.SetActive (false);
			resumeButton.interactable = true;

//			bool pause=re.GetPause();
//			if (pause) {
//				Time.timeScale = 0;
//				back.SetActive (true);

			//}
		} 


	}
	public void onHome(){
		exitButton = !exitButton;
		if (exitButton) {
			Time.timeScale = 0;
			exitDilog.SetActive (true);
			back.SetActive (true);
		}
	}


	public void onYes(){
		exitButton = !exitButton;
		//to no button press
		if (!exitButton) {
			levelmaneger.LoudHome ();
			//SceneManager.LoadScene ("world");
			Time.timeScale = 1;
			exitDilog.SetActive (false);
			back.SetActive (false);
		}
	}
}
