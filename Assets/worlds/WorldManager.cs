using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using System.Collections;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour {



	//if the vareble or method didn't appear on unity use [System.Serializable]
	//doors button 
	public Button level01Button,level02Button, level03Button, level04Button, level05Button, level06Button;
	int levelPassed;
	public Image Image02, Image03, Image04, Image05, Image06;
	//doors changes
	public Sprite win, close, current;
	bool nextavi=true;
	public Animator shaking;


	//do once in the bigining 
	void Start(){
		//get the last passed level from playerprefs
		//int totalscore = PlayerPrefs.GetInt ("total ");


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

	/*void Update(){

		Vector2 shakePostion = Random.insideUnitCircle * shakeAmount;
		transform.position 

	}*/
	//to made animation between the world and level we use invoke("method",sf)
	public void levelToLoad (int level)
	{
		if (level - 1 <= levelPassed)
			SceneManager.LoadScene (level);
		//loud the level dialog 
		//oth	er 
		//Application.LoadLevel (level);

		else {
			shakeworld ();
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
			nextavi = true;
		}
	}
	public void shakeworld(){
		
		shaking.SetBool ("shake", true);
		Invoke ("stopshakeworld",2);
		//GetComponent<CameraShake>().ShakeCamera(20f, 1f);
		//Camera.main.gameObject.GetComponent<CameraShake>().ShakeCamera(20f, 1f);
		//anim.SetBool ("shake", true);
		//Originalpos=;
		//Camera.main.transform.position=Originalpos +Vector3.Scale(SmoothRandom.GetVector2(Shakespeed--),Shakerange);
	}
	public void stopshakeworld(){
		shaking.SetBool ("shake", false);

	}

	//method for test the system 
	public void reset(){
		PlayerPrefs.DeleteAll();
	}

}
