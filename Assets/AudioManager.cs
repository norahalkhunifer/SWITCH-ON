using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

	//set mute status 
	public void ToggleMute(){

		if (PlayerPrefs.GetInt ("Mute", 0) == 0) {
			PlayerPrefs.SetInt ("Mute", 1);

		}else{
			PlayerPrefs.SetInt ("Mute", 0);

		}
	}
}
