using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThenderHide : MonoBehaviour {
	public GameObject thender0;
	public GameObject thender1;
	public GameObject thender2;
	public GameObject thender3;
	public GameObject thender4;
	public GameObject thender5;
	public GameObject thender6;
	public GameObject thender7;
	public GameObject thender8;
	public GameObject hide;

	bool th0=false;
	bool th1=false;
	//bool th2=false;

 float timerr ;
	public string str;
	public AccelerationControlScript script;
	// Use this for initialization


 void Update()
	{ 		
		str = script.temp;
		timerr = script.timer;
		if (timerr>=3) {
			Debug.Log (str + "dd");
				thender0.SetActive (false);//to disable thinder
			hide.SetActive(false);
			script.enabled = true;
			script.timer=0;
			th0 = true;

		}

		if (timerr>=3&&th0==true) {
	Debug.Log (str + "dd");
Debug.Log (str + "ss");
	thender1.SetActive (false);//to disable thinder
		hide.SetActive(false);
			script.enabled = true;

			script.timer=0;
			th1 = true;

}
		if (timerr>=3&&th1==true) {
	Debug.Log (str + "dd");
thender2.SetActive (false);//to disable thinder
			hide.SetActive(false);
			script.enabled = true;

			script.timer=0;

	}

	}
}
