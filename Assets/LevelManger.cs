using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour {

	int levelpassed=PlayerPrefs.GetInt ("LevelPassed");
	int leveltopscore;
	int leveltime;
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
	public void Replay(int level){
		Application.LoadLevel ("Level1");
	}
}
