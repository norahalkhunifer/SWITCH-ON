using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//importaaant

public class TimerText: MonoBehaviour {
	
	public Text gameTimerText;
	float Timer=90;


		void Update () {
			Timer -= Time.deltaTime*24;

			int seconds = (int)(Timer % 60);
			int minutes = (int)(Timer / 60) % 60;
			//		int hours = (int)(Timer / 3600) % 24;

			string timerString = string.Format("{0}:{1}",minutes,seconds);

			gameTimerText.text = timerString;
		}



}