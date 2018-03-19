using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//importaaant
using UnityEngine.SceneManagement;
using UnityEngine.XR.iOS;//important for unityARhitTestexample

public class Level2Manager : MonoBehaviour {

	/*public GameObject balloon1;
	public GameObject balloon2;
	public GameObject balloon3;
	public GameObject balloon4;
	public GameObject balloon5;
	public GameObject balloon6;
	public GameObject balloon7;
	public GameObject balloon8;
	public GameObject balloon9;
	public GameObject balloon10;*/

	//for disactivate onplanecamera
	GameObject hitObject;
	public UnityARHitTestExample hit;
	public GameObject panleOncamera1;

	public int size;
	//time
	public Text time;
	private float timer,timeongoing;
	public float timelimitbysec;
	public Text Topscore,timetext,cscoretext;
	bool end=false,started=false;
	public GameObject score;
	public bool paused=false;

    Balloon b;
	private LevelManger levelM;

	// Use this for initialization
	void Start () {
		//Particle.gameObject.SetActive (false);

		//start timer depend on the complexity 
		timer = Time.time + timelimitbysec;
	}

	void Update ()
	{
		if (!paused && started) {
			Time.timeScale = 1;
		}else 
			Time.timeScale = 0;

		//time untile instruction closes 
		if (started && (!end)) {
			Timedecrising();
		}

	}

	void Timedecrising(){
		print ("enter it");
		timeongoing= timer - Time.time;
		string min = ((int)timeongoing / 60).ToString ();
		string sec = ((int)timeongoing % 60).ToString ();

		if (timeongoing <= 0) {//if time is up 
			time.text ="0";
		} else//we can change it to red if its close to end by 5 or 10 sec 
			time.text = min + ":" + sec;
	}

	/*public void timeend ()
	{

		if (size == 0)
			GameEnd (true);
		else
			GameEnd (false);

	}
	void GameEnd (bool win)
	{
		end = !end;
		//activateGray (true);
		//endpanle.SetActive (true);
		timetext.text = doneTime();
		//cscoretext.text = score.text;
		if (win) {
			//wining.SetActive (true);
			//Topscore.text = scorenum.ToString();
			levelmanger.win (2,scorenum,timetext.text.ToString());
			debugbox.text = "tries: " + nroftries;
		} else {
			lose.SetActive (true);
		}
	}
	string doneTime(){
		return((int)(timer - timeongoing)/60).ToString ()+":"+((int)(timer - timeongoing) % 60).ToString();

	}*/

	public void touchsomething (GameObject hitobject)//if player hit something the hit example will send the hited object to her e
	{

		//get it and openit or close it the mange will be in other method 
		b = hitobject.GetComponent<Balloon> ();

		if (b != null) {

			b.setNo (hitobject);

			if(b.getNo(hitobject) == 2) {
				print ("NO==2");
				b.gameObject.SetActive (false);
				b.playSound ();
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

	public void activateGray (bool open)
	{
		panleOncamera1.SetActive (open);
		paused = open;
		//boxesHit test=hitObject.GetComponent ("boxesHit")as boxesHit;
		hit.enabled = !open;
	}

}
