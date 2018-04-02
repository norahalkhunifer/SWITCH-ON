using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//importaaant
using UnityEngine.SceneManagement;
using UnityEngine.XR.iOS;//important for unityARhitTestexample

public class Level6Manager : MonoBehaviour {


	//for disactivate onplanecamera
	GameObject hitObject;
	public bHitLevel6 hit;
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
	public Text Btext;
	public Text scoret; //to show it in panel
	public Text Topscore,timetext,cscoretext;//for ach details
	public GameObject score ;
	//GameObject winD;

	//time
	public Text time;
	private float timer,timeongoing;
	public float timelimitbysec;
	public Resumepaused re;
	public bool paused =false ,end=false ,started=false;

	//win and lose
	public GameObject endpanle,wining,lose;

	//balloons to assign materials
	public GameObject [] balloons=new GameObject[3];
	//matirals
	System.Random random = new System.Random();
	public Material[] myMaterials = new Material[3];
	Material Rmatiral;
	int i=0;

	// Use this for initialization
	void Start () {
//assign random matirals
		ChooseRandomMaterial ();

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

	//choose random matirals
	void ChooseRandomMaterial(){
		
		for (i = 0; i < 3; i++) {
			Rmatiral=myMaterials [random.Next (0, myMaterials.Length)];
			balloons [i].GetComponent<Balloon> ().setMatiral (Rmatiral);
			balloons [i].transform.GetChild (0).gameObject.GetComponent<Renderer> ().material = Rmatiral;
		    
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

		if (size == 0 || size==2|| size<2)
			GameEnd (true);
		else
			GameEnd (false);

	}

	public void touchsomething (GameObject hitobject)//if player hit something the hit example will send the hited object to her e
	{

		//get it and openit or close it the mange will be in other method 
		b = hitobject.GetComponent<Balloon> ();

		if (b != null) {

			if((b.getSNo(b.normal_material)).Equals("(instance) ")){
				b.playSound1 ();
				b.gameObject.SetActive (false);

				b.showParticle (hitobject);
				//for bonus if it more than 5
				if (size == 2) 
					StartCoroutine("changeDebug", "Yay,you got +1!");
				//count scores 
				Score (1);
				//to stop the game
				size--;
				if (size == 0)
					GameEnd (true);
			}
			/*if (b.normal_material.Equals ("")) {
			}
			if (b.normal_material.Equals ("")) {
			}*/
			//else if (b.getNo() == 1) {
				//print ("NO==1");



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
		StartCoroutine("changeDebug", "Get closer!"); 
		farAud.Play ();
	}



	public void Score(int sc){
		scoreint += sc;

		if (size == 2 || size <2  ) {
			scoret.text =" ";
			Btext.text = scoreint + "";
		} 
		else {
			Btext.text = " ";
			scoret.text = scoreint + "";
		}
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
		cscoretext.text = scoreint+"";

		if (win) {
			winAud.Play ();
			wining.SetActive (true);
			levelM.win (level,scoreint,timetext.text.ToString());
			Topscore.text = levelM.getTopScore (level).ToString ();
			//debugbox.text = "tries: " + nroftries;

		} else {
			loseAud.Play ();
			lose.SetActive (true);
		}
	}

	string doneTime(){
		float DoneTime =  timelimitbysec-timeongoing;

		return((int)DoneTime/60).ToString ()+":"+((int)DoneTime % 60).ToString();	}

	public void onHome(){
		exitDilog.SetActive (false);
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
