using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour {

	/// <summary>
	/// this class is countain the shared metods for all levels 
	/// </summary>

	int levelpassed=PlayerPrefs.GetInt ("LevelPassed");
    int leveltopscore;
	string leveltime;
    int leveltoptime;

	public void win (int levelnum,int cscore, string ctime){
		leveltopscore = getTopScore (levelnum);
		leveltime = getTime (levelnum);

		if (cscore >= leveltopscore) {
			setTopScore (levelnum, cscore);
			setTime (levelnum, ctime);
		}
		if (levelnum > levelpassed) {
			PlayerPrefs.SetInt ("LevelPassed", levelnum);
		}
	}


	//we don't need lose method  , we well not save any data in db 


	public void LoudHome(){
		SceneManager.LoadScene ("world");

	}
	public void LoudLevel(int levelnum){//or string 
		if(levelnum!=-1)
		SceneManager.LoadScene (levelnum);

	}
	/// <summary>
	/// *Level(level number)Score type:int
	/*The top score of winning level 
	Ex:Level3Score,5
	*Level(level number)Time type:string as mm:ss
	The time related to top score 
	Ex:Level3Time,1:50

	*LevelPassed type:int 
	The last level passed 
	If (LevelPassed>=current level )
	Don’t change 
	Else 
	LevelPassed=current level


		*Username type:string
		Username dash 

		*TotalScore type:int 
		The total score change when top score change totalscor—=topscore 
		*CapeColor type:int or bool or any   
		*Sound type:bool*/
	/// </summary>
	
	public int getTopScore (int levelnum){
		return PlayerPrefs.GetInt ("Level"+levelnum+"Score");

	}
	public string getTime (int levelnum){
		return PlayerPrefs.GetString ("Level"+levelnum+"Time");

	}
	public void setTopScore (int levelnum,int topscore){
		 PlayerPrefs.SetInt ("Level"+levelnum+"Score",topscore);

	}
	public void setTime (int levelnum,string time){
		 PlayerPrefs.SetString ("Level"+levelnum+"Time",time);

	}

	public void Replay(int level){//or could be astring 
		Application.LoadLevel (level);
	}






}
