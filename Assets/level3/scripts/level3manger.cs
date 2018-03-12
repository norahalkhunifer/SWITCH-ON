using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class level3manger : MonoBehaviour
{
	//array of boxes in the scean 
	public List<GameObject> boxes = new List<GameObject> ();
	//array countains random objects
	public GameObject[] random;
	//array of objects repetesion 
	private int[] randomthingsrepet;
	//game size (if there is 4 boxes =>size=2)
	public int size;
    //current tutched box
	BoxControl current;
	//current opend boxes 2 at time 
	private BoxControl[] currentboxes = new BoxControl[2];
	//number of tries 
	private int nroftries = 0;
	//time
	public Text time;
	private float timer;
	public float timelimitbysec;
	//score
	public Text score;
	private int scorenum=0;
	//if anyy thing goes wrong
	public Text debugbox;

	//instruction dialog 
	public GameObject instructionpanle;
	private float insttimer=0f;
	//exit dialog
	public GameObject exitD;
	public GameObject panleOncamera;
	GameObject hitObject;
	public boxesHit hit;
	bool paused=false;
	//win and lose objects 
	public GameObject endpanle,wining,lose;
	public Text Topscore,timetext,cscoretext;
	bool end=false;
	//sounds 
	public AudioSource pickup,mismatch,Endwin,Endlose,background;

	//to mange level detels 
	LevelManger levelmanger=new LevelManger();

	//NetworkClient myClient;


	// Use this for initialization
	void Start ()
	{
		//Screen.orientation = ScreenOrientation.Portrait;

		//start timer depend on the complexity 
		timer = Time.time + timelimitbysec;
		randomthingsrepet = new int[random.Length];
		foreach (GameObject box in boxes) {
			placeRandomobj (box);
		}
		Showinstruction (true);
		setScore ();
	}

	//to place objects insaid boxws 
	public void placeRandomobj (GameObject box)
	{
		int randomInt = GetRandom ();
		//to be fair check if it not od or not all have same object 
		if (randomthingsrepet [randomInt] % 2 != 0 || (randomthingsrepet [randomInt] < (size / 2))) {
			Vector3 newpos = new Vector3 (box.transform.position.x, box.transform.position.y + 0.05f, box.transform.position.z);
			GameObject newObject = (GameObject)Instantiate (random [randomInt],newpos, box.transform.rotation, box.transform)as GameObject;
			if(newObject)
			newObject.transform.localScale = new Vector3 (0.007f, 0.007f, 0.007f);// (box.transform.localScale.x-1f, box.transform.localScale.y-1f, box.transform.localScale.z-1f);//(0.005f, 0.005f, 0.005f);// // change its local scale in x y z format


			#if UNITY_EDITOR
			UnityEditor.Selection.activeObject = newObject;
			#endif
			//newObject.AddComponent<>();
			//NetworkServer.Spawn (newObject);


			randomthingsrepet [randomInt] += 1;
			box.GetComponent<BoxControl> ().insaideobj = newObject;
		} else
			placeRandomobj (box);
	}

	int GetRandom ()
	{
		return Random.Range (0, random.Length);
	}

	void Update ()
	{//time decreasing 
		//if inst +pause+home not active 
		//+stop if win or lose 
		if (paused) {
			Time.timeScale = 0;
		} else if (!paused) {
			Time.timeScale = 1;
		}
		insttimer += Time.deltaTime;   
		//time untile instruction closes 
		if (!instructionpanle.activeInHierarchy&& !end) {
			Timedecrising();
		}



	}
	void Timedecrising(){
		float t = timer - Time.time;
		string min = ((int)t / 60).ToString ();
		string sec = ((int)t % 60).ToString ();
		if (t <= 0) {//if time is up 
			timeend();
		} else//we can change it to red if its close to end by 5 or 10 sec 
			time.text = min + ":" + sec;
	}
	public void touchsomething (GameObject hitobject)//if player hit something the hit example will send the hited object to her e
	{
		//get it and openit or close it the mange will be in other method 
		current = hitobject.GetComponent<BoxControl> ();

		//check if there is more than 2 are open if yes then colse them thin opent the tutched one 
		if (current != null) {
			if (current.isOpen ()) {
				//debugbox.text= "This box is already open!";//thats not efftint 
			} else {
				current.openit ();
			}	
		} else
			print ("not box!");//message that says tuch me again!
	}

	//check if there is 2 opened before
	public void CheckBoxes (BoxControl bc)
	{
		//not executed 
		if(bc.insaideobj==null) {
			Debug.Log("null thing");
			bc.closeit();
		}
		//PrefabUtility.GetPrefabParent(gameObject) == null && PrefabUtility.GetPrefabObject(go) != null; // Is a prefab
		if (currentboxes [0] == null && bc!=currentboxes [0])
			currentboxes [0] = bc;
		else {
			currentboxes [1] = bc;
			nroftries++;
			//check if it's not the same box !
			//PrefabUtility.FindPrefabRoot get same name why not working ?
			//Debug.Log ("1 " +PrefabUtility.FindPrefabRoot(currentboxes [0].insaideobj)+"2"+PrefabUtility.FindPrefabRoot(currentboxes [1].insaideobj));
			//if (newAddedGO.name == string.Format("{0}(Clone)", myNeedPrefab.name) {};
			if (currentboxes [0].insaideobj.name ==currentboxes [1].insaideobj.name)//finally works it check the prefab name if its same 
				BoxesMatching ();
			else
				BoxesNotMatching ();

			StartCoroutine("emptyCurrentBoxes");


		}
	}

	public void BoxesMatching ()
	{
		currentboxes [0].mached ();
		currentboxes [1].mached ();
		size--;
		debugbox.text= "YaaY +4 ⚡ ";
		//play yay sound 
		pickup.Play();
		addscore (4);
		if (size == 0)
			GameEnd (true);
	}

	public void BoxesNotMatching ()
	{
		StartCoroutine("closeCurrentBoxes");
		//closeCurrentBoxes();
	}

	IEnumerator closeCurrentBoxes()
	{
		yield return new WaitForSeconds(2);
		currentboxes [0].closeit ();
		currentboxes [1].closeit ();
	}
	IEnumerator emptyCurrentBoxes()
	{
		yield return new WaitForSeconds(2);

	currentboxes [0] = null;
	currentboxes [1] = null;
	}

	public void timeend ()
	{
		if (size == 0)
			GameEnd (true);
		else
			GameEnd (false);

	}
	public void addscore (int addedscore)
	{
		scorenum += addedscore;
		setScore ();
	}
	private void setScore(){
		score.text = scorenum.ToString ();
	}

	void GameEnd (bool win)
	{
		end = !end;
		activateGray (true);
		endpanle.SetActive (true);
		timetext.text = time.text;
		cscoretext.text = score.text;
		if (win) {
			wining.SetActive (true);
			Topscore.text = scorenum.ToString();
			levelmanger.win (2,scorenum,time.text.ToString());
			debugbox.text = "tries: " + nroftries;
		} else {
			lose.SetActive (true);
			}
	}

	public void save (int winscore)
	{
		PlayerPrefs.SetInt ("Level3Score", winscore);

	}
	public void pause ()
	{

	}
	public void home (bool open)
	{
		exitD.SetActive(open);
		paused = open;
		activateGray (open);
	}
	 void activateGray (bool open)
	{
		panleOncamera.SetActive (open);
		//boxesHit test=hitObject.GetComponent ("boxesHit")as boxesHit;
			hit.enabled = !open;
	}
	public void closeLevel ()
	{
		levelmanger.LoudHome ();
	}
	public void ReplayLevel ()
	{
		levelmanger.Replay ();
	}
   public void Showinstruction (bool show)
	{
		instructionpanle.SetActive (show);
	}




}
