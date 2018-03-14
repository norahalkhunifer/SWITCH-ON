using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour {

	public GameObject balloon;
	public GameObject balloon1;
	public GameObject balloon2;
	public GameObject balloon3;
	public GameObject balloon4;
	int No = 0;
	//public GameObject balloon5;
	public GameObject score;
    Balloon b;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void touchsomething (GameObject hitobject)//if player hit something the hit example will send the hited object to her e
	{
		No++;
		//get it and openit or close it the mange will be in other method 
		b = hitobject.GetComponent<Balloon> ();
		if (b != null) {
			//print ("ifind it");
			if (No == 2) {
				print ("lala");
				b.gameObject.SetActive (false);
			}
			b.changePos();
		    //score = score + 1;
		    //Debug.Log (score);
			//scoreText.text = score.ToString ();
			//finalScore.text=score.ToString();
			//scoreTextWin.text=score.ToString();
		} 
	}

}
