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

     public Resumepaused re;


	// Use this for initialization
	void Start () {

	}


	public void onNo(){
		print ("no");

		Time.timeScale = 0;
		exitDilog.SetActive (false);
		l2m.activateGray (true);
		re.setPause (true);


		if(l2m.end==true)
		back2.SetActive (true);	
		else
			back.SetActive (true);
	
	}

	public void onyes(){
		
		lm.LoudHome ();
		print ("yest entered");
		Time.timeScale = 1;
		exitDilog.SetActive (false);


	}

	public void onHome(){
		exitDilog.SetActive (true);
		Time.timeScale = 0;
			back.SetActive (false);

	}
		

}
