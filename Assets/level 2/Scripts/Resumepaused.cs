using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resumepaused : MonoBehaviour {

		 bool paused=false;
	     bool started=false;

	   // public Transform button;
        public Button pausePar;
		public GameObject pauseOBJ;
		//public GameObject back;
		public GameObject inss;
		//public GameObject inssAnim;
	 public Level2Manager l2m;


		// Use this for initialization
		void Start () {

			Time.timeScale = 0;
			instru ();
		}

	public void instru(){
		
		pausePar.interactable = false;

		l2m.activateGray (true);
		pauseOBJ.SetActive (false);
		//back.SetActive (false);
		inss.SetActive (true);
		paused = false;

	}

	public bool getStarted(){
		return started;
	}


		public void onResume(){
		paused = !paused;

			//to resume the game
		if (!paused) {
				Time.timeScale = 1;
			pauseOBJ.SetActive (false);
			l2m.activateGray (false);
			pausePar.interactable = true;
				
			}}
		//to pause the level

		public void OnPause (){
		
		paused = true;
		if (paused ) {
			
			print ("paused");
				Time.timeScale = 0;
			pauseOBJ.SetActive (true);
			l2m.activateGray (true);
				//back.SetActive (true);
			Debug.Log (paused);
			setPause (paused);
			}
		}


		public bool GetPause(){
		
		return paused;	}
	
		public void setPause(bool pa){
		paused=pa;	}

		public void OnIns(){
		//pausePar.interactable () = true;
			//pause = !pause;
		if (paused) {
				Time.timeScale = 0;
			    pauseOBJ.SetActive (false);
			pausePar.interactable = false;
				//back.SetActive (false);
			l2m.activateGray (true);
				inss.SetActive (true);
				//inssAnim.SetActive (true);
			}
		}

		public void onSkip(){
		

		paused = true;
	
			//to no button press
		if (paused) {
			pausePar.interactable = true;
				Time.timeScale = 1;
				//back.SetActive (false);
			    pauseOBJ.SetActive (false);
				inss.SetActive (false);
			    l2m.activateGray (false);
				//inssAnim.SetActive (false);
			started = true;
			paused = false;

			}


		} 


	}



