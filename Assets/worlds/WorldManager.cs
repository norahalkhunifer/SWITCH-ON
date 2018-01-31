using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WorldManager : MonoBehaviour {

	int state ;
	[System.Serializable]
	public class Level
	{
		public string leveltitle;
		public int state;
		public bool isintractible;
		public Button.ButtonClickedEvent onclick;
	}
	//public List<Level> levels;
	//public GameObject levelButton;


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
