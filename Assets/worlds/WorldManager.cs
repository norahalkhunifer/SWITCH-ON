using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour {

	public Button level02Button, level03Button;
	int levelPassed;
	public Image Image02, Image03;

	void Start(){

		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		level02Button.interactable = false;
		level03Button.interactable = false;
		Image02.enabled = true;
		Image02.enabled = true;


		switch (levelPassed) {

		case 1:
			level02Button.interactable = true;
			Image02.enabled = false;
			break;

		case 2:
			level03Button.interactable = true;
			Image03.enabled = false;
			break;

		}
	}


	public void levelToLoad (int level)
	{
		SceneManager.LoadScene (level);
	}
	public void reset(){
		PlayerPrefs.DeleteAll();
	}
}
