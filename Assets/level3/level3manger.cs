using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class level3manger : MonoBehaviour {

	public List<GameObject> boxes = new List<GameObject>(); //array used to keep track of boxes objects
	public int size;//same as array of boxes/2 almost!
	BoxControl current;
	private BoxControl[] currentboxes = new BoxControl[2];
	private int nroftries = 0;
	public Text time;
	private float timer;
	public float timelimitbysec;
	private Text score;

	// Use this for initialization
	void Start () {
		timer = Time.time+timelimitbysec;
	}
	void Update () {
		float t = timer - Time.time;
		string min=((int)t / 60).ToString();
		string sec=((int)t % 60).ToString();
		if (t <= 0) {
			time.text ="done";

		}else//we can change it to red if its close to end by 5 or 10 sec 
		time.text = min + ":" + sec;

	}
	public void touchsomething (GameObject hitobject) {
		//check if its shadow or pairent don't get in 
		//get it and openit or close it the mange will be in other method 
		current = hitobject.GetComponent<BoxControl> ();
		if (current!= null) {
				if (current.isOpen ()) {
					current.closeit ();
				} else {
					current.openit ();

				}	
			}else
				print ("not box!");


	}
	public void home(){
		//SceneManager.LoadScene ("world");
	}

	//check if there is 2 opened before 
	public void CheckBoxes(BoxControl bc){//null point why?
		if(currentboxes[0] == null)
			currentboxes[0] = bc;
		else{
			currentboxes[1] = bc;
			nroftries++;

			if(currentboxes[0].boxnum == currentboxes[1].boxnum)
				BoxesMatching();
			else
				BoxesNotMatching();

			currentboxes[0] = null;
			currentboxes[1] = null;
		}
	}
	public void BoxesMatching(){
		currentboxes[0].mached();
		currentboxes[1].mached();

		size--;
		if(size == 0)
			GameEnd();
	}
	public void BoxesNotMatching(){

		currentboxes[0].closeit();
		currentboxes[1].closeit();
	}

	public void timelimit(){


	}
	void GameEnd(){
		//check wining or loosing
		Debug.Log("Game has ended, number of tries: " + nroftries);
	}
	public void save(int winscore){
		PlayerPrefs.SetInt("level3Score",winscore);
	}


}
