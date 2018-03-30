using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

	public AudioSource music;
	void Start () {
		if (GetMute()) {

				music.mute = false;
		}
		else{
				music.mute = true;
		}


	}
	//set mute status 
	public void ToggleMute(){

		if (GetMute()) {
			SetMute(1);

		}else{
			SetMute( 0);

		}
	}

	public void SetMute(int mute){
		PlayerPrefs.SetInt ("Mute", mute);

	}
	public bool GetMute(){
		return PlayerPrefs.GetInt ("Mute", 0) == 0;
	}

}
