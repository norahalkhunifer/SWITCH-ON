using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resumepaused : MonoBehaviour {

		public bool pause;
	   // public Transform button;
        public Button pausePar;
		public GameObject pauseOBJ;
		//public GameObject back;
		public GameObject inss;
		//public GameObject inssAnim;

		// Use this for initialization
		void Start () {

			Time.timeScale = 0;
			instru ();
		}

	public void instru(){
		pausePar.interactable = false;
		pause = false;
		pauseOBJ.SetActive (false);
		//back.SetActive (false);
		inss.SetActive (true);

	}
		public void onResume(){
			pause = !pause;
			//to resume the game
			if (!pause) {
				Time.timeScale = 1;
			pauseOBJ.SetActive (false);
				//back.SetActive (false);
			}}
		//to pause the level

		public void OnPause (){
		


			pause = true;
		if (pause ) {
			
			print ("paused");
				Time.timeScale = 0;
			pauseOBJ.SetActive (true);
				//back.SetActive (true);
				Debug.Log (pause);
				setPause (pause);
			}
		}

		public bool GetPause(){
			return pause;	}
		public void setPause(bool pa){
			pause=pa;	}

		public void OnIns(){
		//pausePar.interactable () = true;
			//pause = !pause;
			if (pause) {
				Time.timeScale = 0;
			    pauseOBJ.SetActive (false);
				//back.SetActive (false);
				inss.SetActive (true);
				//inssAnim.SetActive (true);
			}
		}
		public void onSkip(){
		pausePar.interactable = true;
			pause = true;
			//to no button press
			if (pause) {
				Time.timeScale = 1;
				//back.SetActive (false);
			    pauseOBJ.SetActive (false);
				inss.SetActive (false);
				//inssAnim.SetActive (false);


			}
		} 


	}



