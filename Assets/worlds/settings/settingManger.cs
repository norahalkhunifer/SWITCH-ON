using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingManger : MonoBehaviour {
	public GameObject charcter1, charcter2, help, skip;
	public Button RedChar, BlueChar;
	public Sprite RedOff, RedOn, BlueOn, BlueOff;
	 WorldManager manger;
	public Image closed, start;
	GameObject text1, text2;

	private AudioManager audiomanager;
	public Button MusicToggle;
	public Button SoundToggle;
	public Sprite MusicOff, MusicOn, SoundOn, SoundOff;

	public void Start(){
		manger= GameObject.Find("worlds manger").GetComponent<WorldManager> ();
		audiomanager = GameObject.FindObjectOfType<AudioManager> ();
		Mute ();
		MuteAll ();
		RedChar.image.overrideSprite = RedOn;
	}

	//method to send email 
	public void ContactUs()
	{
		string email = "switchOn.ksu@gmail.com"; 
		string title = emailURL ("FEEDBACK"); 
		string msg = emailURL ("Please enter your message");

		Application.OpenURL ("mailto:" + email + "?subject=" + title + "&body=" + msg); //open iphone mail 
	}

	string emailURL(string url){

		return WWW.EscapeURL (url).Replace ("+", "%20");
	}
	public void swapToBlue(){

		charcter1.SetActive (true);
		charcter2.SetActive (false);

		BlueChar.image.overrideSprite = BlueOn;
		RedChar.image.overrideSprite = RedOff;

		setCape ("Blue");

	}

	//method to change blue cape to red
	public void swapToRed(){

		charcter2.SetActive (true);
		charcter1.SetActive (false);

		BlueChar.image.overrideSprite = BlueOff;
		RedChar.image.overrideSprite = RedOn;

		setCape ("Red");


	}
	private void setCape(string color){
		PlayerPrefs.SetString("CapeColor",color);

	}
	public void getCapeColor(){
		string color =PlayerPrefs.GetString("CapeColor");
		if (color == "Blue")
			swapToBlue ();
		else if (color == "Red")
			swapToRed ();

	}
	public void showinst(Animator anim){
		manger.closesettings (anim);

		StartCoroutine (ShowInstruction (true, 0f));
	}


	//show instruction using help button 
	IEnumerator ShowInstruction(bool show,float delayTime){
		yield return new WaitForSeconds(delayTime);

		if (!manger.nextavi)
			manger.previos (manger.shaking2);
		help.SetActive (show); 

		skip.SetActive (true);
		closed.enabled = false;
		start.enabled = false;

		text1 = GameObject.Find ("Text1");
		text1.GetComponent<Text>().enabled = false;

		text2 = GameObject.Find ("Text2");
		text2.GetComponent<Text>().enabled = false;

	}

	//Close instruction using SKIP button
	public void closeInstruction()
	{

		help.SetActive (false);
}

	public void StopMusic(){
		audiomanager.ToggleMute();
		Mute ();
	}


	public void StopAllSound(){
		audiomanager.ToggleSound();
		MuteAll ();
	}

	//change maute to unmute and the icon
	void Mute(){

		AudioSource WorldAudio = GameObject.Find("WorldMusic").GetComponent<AudioSource>();

		if(PlayerPrefs.GetInt("Mute",0) == 0)
		{
			WorldAudio.mute = false;
			MusicToggle.image.overrideSprite = SoundOn;
		}
		else{
			WorldAudio.mute = true;
			MusicToggle.image.overrideSprite = SoundOff;
		}
	}

	void MuteAll(){


		if(audiomanager.GetMuteSound())
		{
			AudioListener.volume = 1;
			SoundToggle.image.overrideSprite = MusicOn;
		}
		else{
			AudioListener.volume = 0;
			SoundToggle.image.overrideSprite = MusicOff;
		}
	}

}
