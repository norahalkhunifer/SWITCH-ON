using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExitB : MonoBehaviour {

	public bool exitButton;
	public GameObject exitDilog;
    public GameObject back;
	private LevelManger level;
	public Resume_Paused re;


	// Use this for initialization
	void Start () {
		
		exitButton = false;
		exitDilog.SetActive (false);

	}


	public void onNo(){
		exitButton = !exitButton;

		//to no button press
		//if (!exitButton) {
			Time.timeScale = 1;
		    exitDilog.SetActive (false);
			//back.SetActive (false);
			bool pause=re.GetPause();
			if (pause) {
				Time.timeScale = 0;
				//back.SetActive (true);

			}
		//} 


	}


	public void onHome(){

			Time.timeScale = 0;
		exitDilog.SetActive (true);

		if (exitDilog.activeSelf == true) {
			print ("ll");
			back.SetActive (false);
		}
			
	}



	public void onYes(){
		exitButton = !exitButton;
		//to no button press
		//if (!exitButton) {
			SceneManager.LoadScene ("world");
			Time.timeScale = 1;
		exitDilog.SetActive (false);
			//back.SetActive (false);
		//}
	}
}
