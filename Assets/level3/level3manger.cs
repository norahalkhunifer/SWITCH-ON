using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3manger : MonoBehaviour {

	public List<GameObject> boxes = new List<GameObject>(); //array used to keep track of boxes objects
	public int boxnum;//same as array of boxes/2 almost!
	BoxControl current;
	private BoxControl[] currentboxes = new BoxControl[2];
	private int nroftries = 0;
	// Use this for initialization
	void Start () {

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
	public void CheckBoxes(BoxControl bc){
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

		boxnum--;
		if(boxnum == 0)
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
	public void save(){
		PlayerPrefs.SetInt("level3Score",3);

	}


}
