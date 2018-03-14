using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//importaaant

public class TimerText: MonoBehaviour {
	 float Timer= 60;
	public Text Timertext;

	void Update () {
		Timertext = GetComponent<Text>();
		Timer -= Time.deltaTime;
		if(Timer<=0){
			Timer = 0;
			Timertext.text = Timer.ToString ("f0");//f9 indicates no. of digits
			print (Timer);
		}
		Timertext.text = Timer.ToString ("f0");//f9 indicates no. of digits
		print (Timer);


	}
}