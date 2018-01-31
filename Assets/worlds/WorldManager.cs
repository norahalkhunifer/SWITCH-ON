using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class WorldManager : MonoBehaviour {
	bool nextavi=true;

	int state ;
	[System.Serializable]
	public class Level
	{
		public string leveltitle;
		public int state;
		public bool isintractible;
		public Button.ButtonClickedEvent onclick;
	}
	//Level +world lists
	//public List<Level> levels;
	//public GameObject levelButton;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//animate x pos 
	//slide to next world
	public void next(Animator anim){

		if (nextavi) {
			anim.SetBool ("thereisnext", true);
			nextavi = false;
		}
	}
	//slide to previos world
	public void previos(Animator anim){

		if (!nextavi) {
			anim.SetBool ("thereisnext", false);

			nextavi = true;
		}
	}
	//animate y+x pos
	//slide to setting panel
	public void opensettings(Animator anim){
		anim.SetBool ("settings", true);

	}
	public void closesettings(Animator anim){
		anim.SetBool ("settings", false);

	}

	//go to level(dialog) scenes or give close feedback
	public void gotolevel(string level){
		//check if close or open!


		Application.LoadLevel (level);
	}
}
