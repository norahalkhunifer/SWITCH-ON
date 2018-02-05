using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour {



	//if the vareble or method didn't appear on unity use [System.Serializable]
	//doors button 
	public Button level01Button,level02Button, level03Button;
	int levelPassed;
	public Image Image02, Image03;
	//doors changes
	public Sprite win, close, current;
	bool nextavi=true;

	//do once in the bigining 
	void Start(){

		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		//level02Button.interactable = false;
		//level03Button.interactable = false;
		//Image02.enabled = true;
		//Image03.enabled = true;

		switch (levelPassed) {
		case 6:

			goto case 5;
		case 5:

			goto case 4;
		case 4:

			goto case 3;

		case 3:
			//Image04.enabled = false;
			level03Button.image.overrideSprite = win;
			goto case 2;
		case 2:
		    Image03.enabled = false;
			//level03Button.image.overrideSprite = current; we change it to close and win only 
			level02Button.image.overrideSprite = win;
			goto case 1;

		case 1:
			Image02.enabled = false;
	     	//level02Button.image.overrideSprite = current;
			level01Button.image.overrideSprite = win;
			break;
		}
	}

	//to made animation between the world and level we use invoke("method",sf)
	public void levelToLoad (int level)
	{
		if (level <= levelPassed)
			SceneManager.LoadScene (level);
		//other 
		//Application.LoadLevel (level);
		else {//shake the world 

		}

	}

	public void opensettings(Animator anim){
			anim.SetBool ("settings", true);
			}
		public void closesettings(Animator anim){
		anim.SetBool ("settings", false);
	}

	//animate y+x pos
		//slide to setting panel
	public void next(Animator anim){

			if (nextavi) {
					anim.SetBool ("thereisnext", true);
					nextavi = false;
				}
			}
	//slide to previos world
	public void previos(Animator anim){

		if (!nextavi) {
			anim.SetBool ("thereisnext", false);
			nextavi = true;}
	}
	//method for test the system 
	public void reset(){
		PlayerPrefs.DeleteAll();
	}

}
