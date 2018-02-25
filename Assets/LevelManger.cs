using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour {



	int levelpassed=PlayerPrefs.GetInt ("LevelPassed");
	public int leveltopscore;
	int leveltime;
	public int leveltoptime;
	public GameObject levelDetails;
	public Text scoreText;
	public Text timeText;
	public Text levelnumber;


	public void win (int levelnum,int cscore, string ctime){
		leveltopscore=PlayerPrefs.GetInt ("Level"+levelnum+"Score");
		leveltime=PlayerPrefs.GetInt ("Level"+levelnum+"Time");

		if(cscore>=leveltopscore){
			PlayerPrefs.SetInt ("Level"+levelnum+"Score",cscore);
			PlayerPrefs.SetString ("Level"+levelnum+"Time",ctime);

		}
		if (levelnum > levelpassed) {
			PlayerPrefs.SetInt ("LevelPassed", levelnum);
		}

	}
	public void lose(int level){
	}



	public void LoudHome(){
		SceneManager.LoadScene ("world");

	}
	public int gettopScore (int levelnum){
		return PlayerPrefs.GetInt ("Level"+levelnum+"Score");

	}


	public void Replay(int level){
		Application.LoadLevel ("Level1");
	}


	public void leveldetails(int levelnum){
		levelDetails.SetActive (true);
		leveltopscore=PlayerPrefs.GetInt ("Level"+levelnum+"Score");
		leveltoptime=PlayerPrefs.GetInt ("Level"+levelnum+"topTime");

		scoreText.text=PlayerPrefs.GetInt ("Level"+levelnum+"Score").ToString();
		timeText.text=PlayerPrefs.GetInt ("Level"+levelnum+"topTime").ToString();

		levelnumber.text = levelnum.ToString();



	}



}
