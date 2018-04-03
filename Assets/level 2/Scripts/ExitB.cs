using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ExitB : MonoBehaviour {

	public bool exitButton;
	public GameObject exitDilog;
    public GameObject back;
	public GameObject back2;

	public LevelManger lm;
	public Level2Manager l2m;
	public Level6Manager l6m;

     public Resumepaused re;


	// Use this for initialization
	void Start () {

	}


	public void onNo(){
		print ("no");

		Time.timeScale = 0;
		exitDilog.SetActive (false);
		if(l2m!=null)
		l2m.activateGray (true);
		if(l6m!=null)
		l6m.activateGray (true);

		re.setPause (true);

		if (l2m != null) {
			if (l2m.end == true)
				back2.SetActive (true);
			else
				back.SetActive (true);
		}
		if (l6m != null) {
			if (l6m.end == true)
				back2.SetActive (true);
			else
				back.SetActive (true);
		}
	}



	public void onyes(){
		
		lm.LoudHome ();
		print ("yest entered");
		Time.timeScale = 1;
		exitDilog.SetActive (false);
		re.pausePar.interactable = true;

	}

	public void onHome(){
		re.pausePar.interactable = false;
		exitDilog.SetActive (true);
		Time.timeScale = 0;
			back.SetActive (false);

	}
		

}
