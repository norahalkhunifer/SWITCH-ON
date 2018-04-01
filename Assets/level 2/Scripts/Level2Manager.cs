using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//importaaant
using UnityEngine.SceneManagement;
using UnityEngine.XR.iOS;//important for unityARhitTestexample

public class Level2Manager : MonoBehaviour {



	//for disactivate onplanecamera
	GameObject hitObject;
	public UnityARHitTestExample hit;
	public GameObject panleOncamera1;
	public LevelManger levelM;
	Balloon b;
	int size=7;
	public int level;
	public GameObject debugbox;

	//on home
	public GameObject exitDilog;
	public GameObject back;

	//error audio
	public AudioSource farAud,loseAud,winAud;


	//score
	public int scoreint;//for each hit and total
	public Text scoret; //to show it in panel
	public Text Topscore,timetext,cscoretext;//for ach details
	public GameObject score;
	//GameObject winD;

	//time
	public Text time;
	private float timer,timeongoing;
	public float timelimitbysec;
	public Resumepaused re;
	 public bool paused =false ,end=false ,started=false;

	//win and lose
	public GameObject endpanle,wining,lose;



	// Use this for initialization
	void Start () {
		//Particle.gameObject.SetActive (false);

		//start timer depend on the complexity 
		timer = Time.time + timelimitbysec;


	}

	void Update ()
	{
		
		started = re.getStarted ();
		paused = re.GetPause ();

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
		
		timeongoing= timer - Time.time;
		string min = ((int)timeongoing / 60).ToString ();
		string sec = ((int)timeongoing % 60).ToString ();

		if (timeongoing <= 0) {//if time is up 
			timeend();
		} else//we can change it to red if its close to end by 5 or 10 sec 
			time.text = min + ":" + sec;
	}

	public void timeend ()
	{

		if (size == 0 || size==2)
			GameEnd (true);
		else
			GameEnd (false);

	}

	public void touchsomething (GameObject hitobject)//if player hit something the hit example will send the hited object to her e
	{

		//get it and openit or close it the mange will be in other method 
		b = hitobject.GetComponent<Balloon> ();

		if (b != null) {
			
			if(b.getNo(hitobject) == 0){

				changeDebug("Opps,pocket it again ");
				b.changePos();
			}

			if (b.getNo(hitobject) == 1) {
				print ("NO==1");

				b.playSound1 ();
				b.gameObject.SetActive (false);

				b.showParticle (hitobject);

				Score (1);
				size--;
				if (size == 0)
					GameEnd (true);

			} 
			if (b.getNo (hitobject) > 1) {
				print ("No>2");
				Destroy (b);
			} 

			b.setNo (hitobject);
		    
		} 
	}

	public void activateGray (bool open)
	{
		panleOncamera1.SetActive (open);
		paused = open;
		//boxesHit test=hitObject.GetComponent ("boxesHit")as boxesHit;
		hit.enabled = !open;
	}

	public void farAway(){
		changeDebug ("get closer");
		farAud.Play ();
	}



	public void Score(int sc){
		
		scoreint += sc;
		scoret.text = scoreint +"";
			
	}

	public void ReplayLevel ()
	{
		levelM.Replay ();
	}



	void GameEnd (bool win)
	{
		end = !end;
		activateGray (true);
		endpanle.SetActive (true);
		timetext.text = doneTime();
		cscoretext.text = scoret.text;

		if (win) {
			
			wining.SetActive (true);
			winAud.Play ();
			levelM.win (level,scoreint,timetext.text.ToString());
			Topscore.text = levelM.getTopScore (level).ToString ();
			//debugbox.text = "tries: " + nroftries;
		
		} else {
			lose.SetActive (true);
			loseAud.Play ();
		}
	}

	string doneTime(){
		
		return((int)(timer - timeongoing)/60).ToString ()+":"+((int)(timer - timeongoing) % 60).ToString();

	}

	public void onHome(){
		levelM.LoudHome ();

	}

	public IEnumerator changeDebug(string text){
		
		debugbox.SetActive(true);
		Text t =debugbox.GetComponentInChildren(typeof(Text))as Text;
		t.text= text;
		yield return new WaitForSeconds(1);
		t.text = "";
		debugbox.SetActive(false);

	}


}
