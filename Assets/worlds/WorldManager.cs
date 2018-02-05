using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour {

	public Button level01Button,level02Button, level03Button;
	int levelPassed;
	public Image Image02, Image03;
	public Sprite win, close, current;
	void Start(){

		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		//level02Button.interactable = false;
		//level03Button.interactable = false;
		//Image02.enabled = true;
		//Image03.enabled = true;


		switch (levelPassed) {


		case 3:
			level03Button.image.overrideSprite = win;
			break;
		case 2:
		//	level03Button.interactable = true;
		Image03.enabled = false;
			level03Button.image.overrideSprite = current;
			level02Button.image.overrideSprite = win;
			//level02Button.transform.localScale = new Vector2 (12.64575f,13.33239f);//rectTransform.sizeDelta = new Vector2 ();
			//level02Button.transform.localScale.Scale.X=12.64575;
			//level02Button.transform.localScale.Scale.Y=13.33239;


		case 1:
			//level02Button.interactable = true;
			Image02.enabled = false;
			level02Button.image.overrideSprite = current;
			level01Button.image.overrideSprite = win;
			break;
		

		}
	}


	public void levelToLoad (int level)
	{
		//if(
		SceneManager.LoadScene (level);
	}
	public void reset(){
		PlayerPrefs.DeleteAll();
	}
	public void movetoworld2(){
		//thereisnext
	}
	public void settings(){
		//thereisnext
	}

}
