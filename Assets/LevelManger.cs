using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManger : MonoBehaviour {

	int levelpassed=PlayerPrefs.GetInt ("LevelPassed");

	public void win (int level,string topscore,string time){
		if (level > levelpassed) {
			PlayerPrefs.SetInt ("LevelPassed", level);
		}
		SceneManager.LoadScene ("world");


	}
	//public void lo
public void lose(int level){
		SceneManager.LoadScene ("world");

			}
}
