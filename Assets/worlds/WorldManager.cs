using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using System.Collections;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour {
	/// <summary>
	/// this class countain the world mithods and dialogncs 
	/// </summary>

	//if the vareble or method didn't appear on unity use [System.Serializable]
	//doors button 
	public Button level01Button,level02Button, level03Button, level04Button, level05Button, level06Button;
	//locked doors
	public Image Image02, Image03, Image04, Image05, Image06;
	//doors changes
	public Sprite win, close;
	bool nextavi=true;
	int levelPassed;
	public Animator shaking;
	public Text totalScore;
	//levels dialogs 
	//public
	LevelManger levelsmanger;
    int leveltopscore;
	int worldtopscore;
	string leveltime;
	public GameObject levelDetailsY, levelDetailsG,levelDetails;
	public settingManger setting;

	public Text scoreText;
	public Text timeText;
	public Text levelnumber;
	int clevel=-1;
	public Button playbtn;
	public bool dialogactive=false;
	public SetGetName dialogsmanger;

	//do once in the bigining 
	void Start(){
		Screen.orientation = ScreenOrientation.Landscape;

		//setting.charcter1.transform.position = level02Button.transform.position;//change position of blue character
		//setting.charcter2.transform.position = level02Button.transform.position;//change posiition of red character

		//ShowInstruction (true);
		//get total score 
		totalScore.text=getTotalScore().ToString();
		levelsmanger=new LevelManger();
		setting = GameObject.Find("setting manger").GetComponent<settingManger> ();
		playbtn.onClick.AddListener(levelToLoad);

		//get the last passed level from playerprefs
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		//to change doors images depend on last passed level
		switch (levelPassed) {
		case 6:
			setting.charcter1.transform.position = level06Button.transform.position;
			setting.charcter2.transform.position = level06Button.transform.position;

			level06Button.image.overrideSprite = win;
			goto case 5;
		case 5:
			setting.charcter1.transform.position = level06Button.transform.position;
			setting.charcter2.transform.position = level06Button.transform.position;

			Image06.enabled = false;
			level05Button.image.overrideSprite = win;
			goto case 4;
		case 4:
			setting.charcter1.transform.position = level05Button.transform.position;
			setting.charcter2.transform.position = level05Button.transform.position;

			Image05.enabled = false;
			level04Button.image.overrideSprite = win;
			goto case 3;
		case 3:
			setting.charcter1.transform.position = level04Button.transform.position;
			setting.charcter2.transform.position = level04Button.transform.position;

			Image04.enabled = false;
			level03Button.image.overrideSprite = win;
			goto case 2;
		case 2:
			setting.charcter1.transform.position = level03Button.transform.position;
			setting.charcter2.transform.position = level03Button.transform.position;

		    Image03.enabled = false;
			//level03Button.image.overrideSprite = current; we change it to close and win only 
			level02Button.image.overrideSprite = win;
			goto case 1;
		case 1:
			setting.charcter1.transform.position = level02Button.transform.position;//change position of blue character
			setting.charcter2.transform.position = level02Button.transform.position;//change posiition of red character

			Image02.enabled = false;
			level01Button.image.overrideSprite = win;
			break;
		}
		setting.getCapeColor ();

		worldtopscore = levelsmanger.getTotalScreore ();
		totalScore.text = worldtopscore.ToString ();
	}

	void Update(){


	}
	//to made animation between the world and level we use invoke("method",sf)
	public void levelToLoad ()
	{
		levelsmanger.LoudLevel (clevel);
		//loud the level dialog 
		//if (level - 1 <= levelPassed && !dialogactive ) { 
			//leveldetails (level);
			//levelsmanger.LoudLevel (level);
		//}

		//} else if (dialogactive) {
			//if dailog is already open 
		//}
		//else {
			//shakeworld ();
		//}

	}

	//settings page animations 
	public void opensettings(Animator anim){
		if(!isDActivated())
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
	public void leveldetails(int levelnum){
		//if (level - 1 <= levelPassed && !dialogactive) {}else {  shakeworld ();  }     
		if (levelnum - 1 <= levelPassed && !isDActivated() ) {

			clevel = levelnum;
			leveltopscore = levelsmanger.getTopScore (levelnum);
			leveltime = levelsmanger.getTime (levelnum);
			scoreText.text = leveltopscore.ToString();
			timeText.text = leveltime.ToString();
			levelnumber.text = levelnum.ToString ();
			levelDetails.SetActive (true);
			if (leveltopscore == 0 ) {
				timeText.text = "0:00";
				levelDetailsG.SetActive (true);
			}//end if 

	else {
				levelDetailsY.SetActive (true);

			}
		}


		else {  
			shakeworld ();  
		}
	}
	/// Closes the level details.



	public void closeLevelDetails() {
		clevel = -1;
		levelDetails.SetActive (false);
		levelDetailsY.SetActive (false); 
		levelDetailsG.SetActive (false); 

	}
	//method for test the system 
	public void reset(){
		PlayerPrefs.DeleteAll();
	}
	public int getTotalScore(){
		return PlayerPrefs.GetInt("TotalScore");
	}
	public void setTotalScore(int totalscore){
		PlayerPrefs.SetInt("TotalScore",totalscore);
	}
	bool isDActivated(){
		if (dialogsmanger.nameDialouge.activeInHierarchy || dialogsmanger.welcomeBack.activeInHierarchy || dialogsmanger.welcomeDialouge.activeInHierarchy)
			return true;
		return false;
	}
		
  
	 }


