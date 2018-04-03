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
	public Level6Manager l6m;
	public Text rColor;//text of color on ins dialouge

	System.Random random = new System.Random();
	private string[] randomNO = new string[]{"Red" , "Blue" , "Green"};

		// Use this for initialization
		void Start () {

			Time.timeScale = 0;
		if (l6m != null) {
			string r = randomNO [random.Next (0, randomNO.Length)];
			rColor.text = r;

			l6m.setColor (r);//send it to level manager
		}
			instru ();

		}

	public void instru(){
		
		pausePar.interactable = false;
		if(l2m!=null)
		l2m.activateGray (true);
		
		if(l6m!=null)
		l6m.activateGray (true);
		
		pauseOBJ.SetActive (false);
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
			if(l2m!=null)
			l2m.activateGray (false);
			if(l6m!=null)
			l6m.activateGray (false);
			pausePar.interactable = true;
				
			}}
		//to pause the level

		public void OnPause (){
		
		paused = true;
		if (paused ) {
			
			print ("paused");
				Time.timeScale = 0;
			pauseOBJ.SetActive (true);
			if(l2m!=null)
			l2m.activateGray (true);
			if(l6m!=null)
			l6m.activateGray (true);
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
			if(l2m!=null)
			l2m.activateGray (true);
			if(l6m!=null)
			l6m.activateGray (true);
				inss.SetActive (true);
				//inssAnim.SetActive (true);
			}
		}

		public void onSkip(){
		

		paused = true;
		print ("skip");
			//to no button press
		if (paused) {
			Time.timeScale = 1;
			pausePar.interactable = true;
			    pauseOBJ.SetActive (false);
				inss.SetActive (false);
			if(l2m!=null)
			    l2m.activateGray (false);
			if(l6m!=null)
			l6m.activateGray (false);
				//inssAnim.SetActive (false);
			started = true;
			paused = false;

			}


		} 


	}



