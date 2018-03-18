using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour {

	public GameObject balloon;
	public GameObject balloon1;
	public GameObject balloon2;
	public GameObject balloon3;
	public GameObject balloon4;
	public GameObject balloon5;
	public GameObject balloon6;
	public GameObject balloon7;
	public GameObject balloon8;
	public GameObject balloon9;
	public GameObject balloon10;

	public GameObject score;

    Balloon b;


	// Use this for initialization
	void Start () {
		//Particle.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void touchsomething (GameObject hitobject)//if player hit something the hit example will send the hited object to her e
	{

		//get it and openit or close it the mange will be in other method 
		b = hitobject.GetComponent<Balloon> ();

		if (b != null) {

			b.setNo (hitobject);

			if(b.getNo(hitobject) == 2) {
				print ("NO==2");
				b.gameObject.SetActive (false);
				//Particle.gameObject.SetActive (true);
				b.showParticle(hitobject);
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
