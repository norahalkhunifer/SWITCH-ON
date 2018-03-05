﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class level3manger : MonoBehaviour
{

	public List<GameObject> boxes = new List<GameObject> ();
	//array used to keep track of boxes objects
	public GameObject[] random;
	//array of objects name
	private int[] randomthingsrepet;
	//array of objects name
	public int size;
//same as array of boxes/2 almost!
	BoxControl current;
	private BoxControl[] currentboxes = new BoxControl[2];
	private int nroftries = 0;
	public Text time;
	public Text debugbox;
	private float timer;
	public float timelimitbysec;
	public Text score;
	private int scorenum=0;
	NetworkClient myClient;

	//instruction
	public GameObject instructionpanle;
	// Use this for initialization
	void Start ()
	{
		//start timer depend on the complexity 
		timer = Time.time + timelimitbysec;
		randomthingsrepet = new int[random.Length];
		SetupClient ();
		//add all boxes to array why ? couse they will have same index as there random object insaide 
		foreach (GameObject box in boxes) {
			placeRandomobj (box);
			//Instantiate (RandomGenrator.placeRandomobj(),box.transform.position,box.transform.rotation,box.transform);
		}
		setScore ();
	}
	public void SetupClient()
	{
		for(int i=0;i<random.Length;i++)
			ClientScene.RegisterPrefab(random[i]);

		myClient = new NetworkClient();

		myClient.RegisterHandler(MsgType.Connect, OnConnected);
		myClient.Connect("127.0.0.1", 4444);
	}
	void OnConnected(NetworkMessage netMsg)
	{
		Debug.Log("Client connected");
	}
	//to place objects insaid boxws 
	public void placeRandomobj (GameObject box)
	{
		int randomInt = GetRandom (random.Length);
		//to be fair check if it not od or not all have same object 
		if (randomthingsrepet [randomInt] % 2 != 0 || (randomthingsrepet [randomInt] < (size / 2))) {
			Vector3 newpos = new Vector3 (box.transform.position.x, box.transform.position.y + 0.05f, box.transform.position.z);
			GameObject newObject = (GameObject)Instantiate (random [randomInt],newpos, box.transform.rotation, box.transform)as GameObject;
			if(newObject)
			newObject.transform.localScale = new Vector3 (0.007f, 0.007f, 0.007f);// (box.transform.localScale.x-1f, box.transform.localScale.y-1f, box.transform.localScale.z-1f);//(0.005f, 0.005f, 0.005f);// // change its local scale in x y z format
			#if UNITY_EDITOR
			UnityEditor.Selection.activeObject = newObject;
			#endif
			randomthingsrepet [randomInt] += 1;
			box.GetComponent<BoxControl> ().insaideobj = newObject;
		} else
			placeRandomobj (box);
	}

	int GetRandom (int count)
	{
		return Random.Range (0, count);
	}

	void Update ()
	{//time decreasing 
		//if inst +pause+home not active 
		//+stop if win or lose 
		Timedecrising();
	}
	void Timedecrising(){
		float t = timer - Time.time;
		string min = ((int)t / 60).ToString ();
		string sec = ((int)t % 60).ToString ();
		if (t <= 0) {//if time is up 
			time.text = "0:15";//game end 
			//home ();
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
				//current.closeit ();
			} else {
				current.openit ();

			}	
		} else
			print ("not box!");//message that says tuch me again!
	}

	//check if there is 2 opened before
	public void CheckBoxes (BoxControl bc)
	{
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

			currentboxes [0] = null;
			currentboxes [1] = null;
		}
	}

	public void BoxesMatching ()
	{
		currentboxes [0].mached ();
		currentboxes [1].mached ();
		size--;
		debugbox.text= "metion compleat";
		addscore (4);
		BoxesNotMatching ();
		if (size == 0)
			GameEnd ();
	}

	public void BoxesNotMatching ()
	{

		currentboxes [0].closeit ();
		currentboxes [1].closeit ();
	}

	public void timelimit ()
	{


	}
	public void addscore (int addedscore)
	{
		scorenum += addedscore;
		setScore ();
	}
	private void setScore(){
		score.text = scorenum.ToString ();
	}

	void GameEnd ()
	{
		//check wining or loosing
		debugbox.text=  "tries: " + nroftries;
	}

	public void save (int winscore)
	{
		PlayerPrefs.SetInt ("Level3Score", winscore);

	}
	public void pause ()
	{

	}
	public void home ()
	{
		SceneManager.LoadScene ("world");
	}


}
