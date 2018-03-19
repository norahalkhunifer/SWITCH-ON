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
    public float timer = 0f;
	public string str;
	public AccelerationControlScript script;
	// Use this for initialization


	public void diseble(string str)
	{ 		
		timer+= Time.deltaTime; 

		Debug.Log (timer+"ww");

				
		if (str.Equals ("grass0")) {
			Debug.Log (str + "dd");
			if (timer >= 1) {
				Debug.Log (str + "ss");
				Debug.Log (timer+"ss");

				thender0.SetActive (false);//to disable thinder
				timer=0f;
			
			}
		}
		if (str.Equals ("grass1")) {
			Debug.Log (str + "dd");
			if (timer >= 1) {
				Debug.Log (str + "ss");
				Debug.Log (timer+"ss");

				thender1.SetActive (false);//to disable thinder
				timer=0f;

			}
		}
		if (str.Equals ("grass3")) {
			Debug.Log (str + "dd");
			if (timer >= 1) {
				Debug.Log (str + "ss");
				Debug.Log (timer+"ss");

				thender2.SetActive (false);//to disable thinder
				timer=0f;

			}
		}
	}
}
