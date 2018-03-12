using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_Paused : MonoBehaviour {
	public bool pause;
	public GameObject resume;
	public GameObject back;
	public GameObject inss;
	public GameObject inssAnim;
	public AccelerationControlScript grass;
	// Use this for initialization
	void Start () {

		Time.timeScale = 0;
		instru ();
	}
	public void instru(){
		pause = false;
		resume.SetActive (false);
		back.SetActive (false);
		inss.SetActive (true);
		inssAnim.SetActive(true);
	}
	public void onResume(){
		pause = !pause;
		//to resume the game
		if (!pause) {
			Time.timeScale = 1;
			resume.SetActive (false);
			back.SetActive (false);
		}}
	//to pause the level

		public void OnPause (){
		pause = true;
 		if (pause) {

			Time.timeScale = 0;
			resume.SetActive (true);
			back.SetActive (true);
			Debug.Log (pause);
			setPause (pause);
			}
		}
	public bool GetPause(){
		return pause;	}
	public void setPause(bool pa){
		 pause=pa;	}
	
	public void OnIns(){
		//pause = !pause;
		if (pause) {
			Time.timeScale = 0;
			resume.SetActive (false);
			back.SetActive (false);
			inss.SetActive (true);
			inssAnim.SetActive (true);
		}
	}
	public void onSkip(){
		pause = true;
		//to no button press
		if (pause) {
			Time.timeScale = 1;
			back.SetActive (false);
			resume.SetActive (false);
			inss.SetActive (false);
			inssAnim.SetActive (false);


			}
		} 

		
	}


