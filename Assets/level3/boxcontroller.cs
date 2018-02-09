using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class boxcontroller : MonoBehaviour {

	private Animation opining;
	private bool isopen=false;
	// Use this for initialization
	void Start () {

		opining = GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	public void openit(){
		//animation.CrossFade ("walk");

			opining.Play ("box_open");
		    isopen = true;

	}
	public void closeit(/* box number !*/){
		opining.Play ("box_close");
		//opining.Stop ();
		isopen = false;
	}
}
