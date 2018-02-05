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

	public float Shakespeed=50f;
	public Vector3 Shakerange =new Vector3(1,1,1);

	//do once in the bigining 
	void Start(){
		//get the last passed level from playerprefs
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		//to change doors images depend on last passed level
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
			level01Button.image.overrideSprite = win;
			break;
		}
	}

	//to made animation between the world and level we use invoke("method",sf)
	public void levelToLoad (int level)
	{
		if (level - 1 <= levelPassed)
			SceneManager.LoadScene (level);
		//loud the level dialog 
		//oth	er 
		//Application.LoadLevel (level);

		else {//shake the world 
			//Animator
			//shake();
		}

	}
	//settings page animations 
	public void opensettings(Animator anim){
			anim.SetBool ("settings", true);
			}
	public void closesettings(Animator anim){
		anim.SetBool ("settings", false);
	}
    //world animations 
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
	/*public void shakeworld(){
		//anim.SetBool ("shake", true);
		Originalpos=;
		Camera.main.transform.position=Originalpos +Vector3.Scale(SmoothRandom.GetVector2(Shakespeed--),Shakerange);
	}*/
	//method for test the system 
	public void reset(){
		PlayerPrefs.DeleteAll();
	}

}
