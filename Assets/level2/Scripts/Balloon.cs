using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	public GameObject balloon;
	//public GameObject balloon1;
	//public GameObject balloon2;
	//public GameObject balloon3;
	//public GameObject balloon4;
	//public GameObject balloon5;

	//public GameObject thunder;
	public GameObject score;


	// Update is called once per frame
	void Update () {
		//thunder.SetActive (false);
	}
		
	/*public void touchsomething (GameObject hitobject)//if player hit something the hit example will send the hited object to her e
	{
		//get it and openit or close it the mange will be in other method 
		balloon = hitobject.GetComponent<BoxControl> ();
		if (balloon != null) {
			if (balloon. {
				balloon.closeit ();
			} else {
				balloon.openit ();

			}	
		} else
			print ("not box!");//message that says tuch me again!
	}*/

	public void disappear(GameObject go){
		
		if ( balloon.name==go.name) {
			Debug.Log (score);
			balloon.SetActive (false);//to disable balloon
		   // thunder.SetActive (true);
			//score = score + 1;
			//Debug.Log (score);
			//scoreText.text = score.ToString ();
			//finalScore.text=score.ToString();
			//scoreTextWin.text=score.ToString();

		}

		/*if ( balloon1.name==go.name) {
			Debug.Log (score);

			balloon1.SetActive (false);//to disable balloon
	     	//thunder.SetActive (true);
			//score = score + 1;
			//Debug.Log (score);
			//scoreText.text = score.ToString ();
			//finalScore.text=score.ToString();
			//scoreTextWin.text=score.ToString();

		}

		if ( balloon2.name==go.name) {
			Debug.Log (score);
			balloon2.SetActive (false);//to disable balloon
			//thunder.SetActive (true);
			//score = score + 1;
			//Debug.Log (score);
			//scoreText.text = score.ToString ();
			//finalScore.text=score.ToString();
			//scoreTextWin.text=score.ToString();

		}/*

		if ( balloon3.name==go.name) {
			Debug.Log (score);

			balloon3.SetActive (false);//to disable balloon
			thunder.SetActive (true);
			//score = score + 1;
			//Debug.Log (score);
			//scoreText.text = score.ToString ();
			//finalScore.text=score.ToString();
			//scoreTextWin.text=score.ToString();

		}

		if ( balloon4.name==go.name) {
			Debug.Log (score);

			balloon4.SetActive (false);//to disable balloon
			thunder.SetActive (true);
			//score = score + 1;
			//Debug.Log (score);
			//scoreText.text = score.ToString ();
			//finalScore.text=score.ToString();
			//scoreTextWin.text=score.ToString();

		}

		if ( balloon5.name==go.name) {
			Debug.Log (score);

			balloon5.SetActive (false);//to disable balloon
			thunder.SetActive (true);
			//score = score + 1;
			//Debug.Log (score);
			//scoreText.text = score.ToString ();
			//finalScore.text=score.ToString();
			//scoreTextWin.text=score.ToString();

		}*/
	}


	}

